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

namespace WAEngine
{
    class Identify
    {
        IMapControlEvents2_OnDoubleClickEvent e;
        public IMapControlEvents2_OnDoubleClickEvent E
        {
            get
            {
                return e;
            }

            set
            {
                e = value;
            }
        }

        AxMapControl axMapControl1;
        public AxMapControl AxMapControl1
        {
            get
            {
                return axMapControl1;
            }

            set
            {
                axMapControl1 = value;
            }
        }
        //获取查询位置
        public void Iddd()
        {

            //获取鼠标点击位置点
            IPoint point = new PointClass();
            point.PutCoords(e.mapX, e.mapY);
            string output = "";
            for (int i = 0; i < axMapControl1.LayerCount; i++)
            {
                output += Identify_layer(axMapControl1.get_Layer(i), point);
            }
            MessageBox.Show(output);


        }
        //识别
        private string Identify_layer(ILayer layer, IPoint SelectedPoint)
        {
            //定义几何图形
            IGeometry pGeometry;
            //定义结果字符串
            string output = "";
            //如果是矢量图层
            if (layer is IFeatureLayer)
            {
                //图层转Identify对象
                IIdentify pFL = layer as IIdentify;
                //对点进行缓冲赋给几何图形，尽量减少对空白区域判定
                ITopologicalOperator pTopo = SelectedPoint as ITopologicalOperator;
                pGeometry = pTopo.Buffer(0);
                //将几何图形作为输入传入Identify对象，进行识别
                IArray id_result = pFL.Identify(pGeometry);
                if (id_result != null)
                {
                    //对识别结果中的记录进行遍历（由于缓冲扩大，可能识别到同一图层多条记录）
                    for (int i = 0; i < id_result.Count; i++)
                    {
                        //获取识别结果记录中的属性记录
                        IIdentifyObj featureIdentifyobj = (IIdentifyObj)id_result.get_Element(i);
                        IRowIdentifyObject iRowIdentifyObject = featureIdentifyobj as IRowIdentifyObject;
                        IRow pRow = iRowIdentifyObject.Row;//添加引用GeoDatabase
                        output += "\"" + featureIdentifyobj.Layer.Name + "\":\n";
                        //遍历属性记录，获取字段名、字段值
                        for (int a = 0; a < pRow.Fields.FieldCount; a++)
                        {
                            if (pRow.Fields.get_Field(a).Type != esriFieldType.esriFieldTypeGeometry)
                            {
                                output += String.Format("{0}={1} \n", pRow.Fields.get_Field(a).Name, pRow.get_Value(a).ToString());
                            }
                        }
                    }
                }
            }
            else if (layer is IRasterLayer)
            {
                //图层转Identify对象
                IIdentify pFL = layer as IIdentify;
                //点转几何对象
                pGeometry = SelectedPoint as IGeometry;
                //将几何图形作为输入传入Identify对象，进行识别
                IArray id_result = pFL.Identify(pGeometry);
                if (id_result != null)
                {
                    //遍历识别结果记录，获取图层名和对应位置的属性值
                    for (int i = 0; i < id_result.Count; i++)
                    {
                        IIdentifyObj featureIdentifyobj = (IIdentifyObj)id_result.get_Element(i);
                        IRasterIdentifyObj rasterIdentifyobj = featureIdentifyobj as IRasterIdentifyObj;
                        output += "\"" + featureIdentifyobj.Layer.Name + "\":" + "\n" + rasterIdentifyobj.MapTip + "\n";
                    }
                }
            }

            return output + "\n";
        }
    }
}
