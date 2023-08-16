using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.DataSourcesOleDB;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.GlobeCore;
using ESRI.ArcGIS.Output;
using ESRI.ArcGIS.SystemUI;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace WAEngine
{
    public partial class frmQueryByAttribute : Form
    {
        public IMap currentMap;
        IFeatureLayer currentFeatureLayer;
        string currentFieldName;
        public frmQueryByAttribute(IMap pMap)
        {
            InitializeComponent();
            currentMap = pMap;
        }

        private void frmQueryByAttribute_Load(object sender, EventArgs e)
        {
            string layerName;//设置临时变量存储图层名称
            for (int i = 0; i < currentMap.LayerCount; i++)
            {
                layerName = currentMap.get_Layer(i).Name;
                cbo_LayerName.Items.Add(layerName);
            }
            //将cbo_LayerName控件的默认选项设置为第一个图层名称
            //cbo_LayerName.SelectedIndex = 0;
            //将cbo_SelectMethod控件的默认选项设置为第一种选择方式
            //cbo_SelectMethod.SelectedIndex = 0;
        }
        //要素选择
        private void cbo_LayerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            lst_Fields.Items.Clear();
            lst_Value.Items.Clear();
            IField field;//设置临时变量存储使用IField接口的对象
            for (int i = 0; i < currentMap.LayerCount; i++)
            {
                if (currentMap.get_Layer(i) is GroupLayer)
                {
                    ICompositeLayer compositeLayer = currentMap.get_Layer(i) as ICompositeLayer;
                    for (int j = 0; i < compositeLayer.Count; j++)
                    {
                        //判断图层的名称是否与cbo_LayerName控件中选择的图层名称相同
                        if (compositeLayer.get_Layer(j).Name == cbo_LayerName.SelectedItem.ToString())
                        {
                            //如果相同则设置为整个窗体使用的IFeatureLayer接口对象
                            currentFeatureLayer = compositeLayer.get_Layer(j) as IFeatureLayer;
                            break;
                        }
                    }
                }
                else
                {
                    //判断图层的名称是否与comboxLayerName控件中选择的图层名称相同
                    if (currentMap.get_Layer(i).Name == cbo_LayerName.SelectedItem.ToString())
                    {
                        //如果相同则设置为整个窗体所使用的IFeatureLayer接口对象
                        currentFeatureLayer = currentMap.get_Layer(i) as IFeatureLayer;
                        break;
                    }
                }
            }
            //使用IFeatureClass接口对该图层的所有属性字段进行遍历，并填充listboxField控件
            for (int i = 0; i < currentFeatureLayer.FeatureClass.Fields.FieldCount; i++)
            {
                //根据索引值获取图层的字段
                field = currentFeatureLayer.FeatureClass.Fields.get_Field(i);
                //排除SHAPE字段，并在其他字段名称前后添加字符“\”
                if (field.Name.ToUpper() != "SHAPE")
                    lst_Fields.Items.Add("\"" + field.Name + "\"");
            }
            //更新labelSelectResult控件中的图层名称信息
            lbl_SelectResult.Text = "SELECT * FROM " + currentFeatureLayer.Name + " WHERE:";
            //将显示where语句的文本内容清除
            rtx_SelectResult.Clear();
        }

        private void lst_Fields_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = lst_Fields.SelectedItem.ToString();
            str = str.Substring(1);
            str = str.Substring(0, str.Length - 1);
            currentFieldName = str;
        }
        //显示唯一值
        private void btn_unique_Click(object sender, EventArgs e)
        {
            lst_Value.Items.Clear();
            IQueryFilter pQueryfilter = new QueryFilterClass();
            IFeatureCursor pFeatureCursor = null;

            pQueryfilter.SubFields = currentFieldName;
            pFeatureCursor = currentFeatureLayer.FeatureClass.Search(pQueryfilter, true);
            IDataStatistics pDataStati = new DataStatisticsClass();
            pDataStati.Field = currentFieldName;
            pDataStati.Cursor = (ICursor)pFeatureCursor;

            IFields fields = currentFeatureLayer.FeatureClass.Fields;
            IField field = fields.get_Field(fields.FindField(currentFieldName));

            System.Collections.IEnumerator pEnumertaor = pDataStati.UniqueValues;
            pEnumertaor.Reset();
            while (pEnumertaor.MoveNext())
            {
                if (field.Type == esriFieldType.esriFieldTypeString)
                {
                    object obj = pEnumertaor.Current;
                    lst_Value.Items.Add("\'" + obj.ToString() + "\'");

                }
                else
                {
                    object obj = pEnumertaor.Current;
                    lst_Value.Items.Add(obj.ToString());
                }

            }
        }
        //增加字段名称
        private void lst_Fields_DoubleClick(object sender, EventArgs e)
        {
            rtx_SelectResult.Text += lst_Fields.SelectedItem.ToString();
        }

        //添加等于号=
        private void btn_Equal_Click(object sender, EventArgs e)
        {
            rtx_SelectResult.Text += " " + btn_Equal.Text + " ";
        }
        //添加唯一值
        private void lst_Value_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            rtx_SelectResult.Text += lst_Value.SelectedItem.ToString();
        }
        //选择要素
        private void SelectFeatureByAttribute()
        {
            IFeatureSelection featureSelection = currentFeatureLayer as IFeatureSelection;
            IQueryFilter queryFilter = new QueryFilterClass();
            queryFilter.WhereClause = rtx_SelectResult.Text;
            IActiveView activeView = currentMap as IActiveView;
            switch (cbo_SelectMethod.SelectedIndex)
            {
                case 0:
                    currentMap.ClearSelection();
                    featureSelection.SelectFeatures(queryFilter, esriSelectionResultEnum.esriSelectionResultNew, false);
                    break;
                case 1:
                    featureSelection.SelectFeatures(queryFilter, esriSelectionResultEnum.esriSelectionResultAdd, false);
                    break;
                case 2:
                    featureSelection.SelectFeatures(queryFilter, esriSelectionResultEnum.esriSelectionResultXOR, false);
                    break;
                case 3:
                    featureSelection.SelectFeatures(queryFilter, esriSelectionResultEnum.esriSelectionResultAdd, false);
                    break;
                default:
                    currentMap.ClearSelection();
                    featureSelection.SelectFeatures(queryFilter, esriSelectionResultEnum.esriSelectionResultNew, false);
                    break;
            }
            activeView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, activeView.Extent);
        }
        //应用
        private void btn_apply_Click(object sender, EventArgs e)
        {
            SelectFeatureByAttribute();
        }
        //确定
        private void btn_ok_Click(object sender, EventArgs e)
        {
            try
            {
                SelectFeatureByAttribute();
                this.Close();

            }
            catch { }
        }
        //清空
        private void btn_clear_Click(object sender, EventArgs e)
        {
            rtx_SelectResult.Clear();
        }
        //退出
        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
