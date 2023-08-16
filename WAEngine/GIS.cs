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
using System.Data.SqlClient;

namespace WAEngine
{
    public partial class GIS : Form
    {
        string GeoOpType = string.Empty;
        public GIS()
        {
            ESRI.ArcGIS.RuntimeManager.Bind(ESRI.ArcGIS.ProductCode.EngineOrDesktop);
            InitializeComponent();
        }

        //自动更新车票信息
        private void GIS_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“railwayDataSet1.fare”中。您可以根据需要移动或删除它。
            this.fareTableAdapter.Fill(this.railwayDataSet1.fare);
            // TODO: 这行代码将数据加载到表“railwayDataSet.k_deatil”中。您可以根据需要移动或删除它。
            this.k_deatilTableAdapter.Fill(this.railwayDataSet.k_deatil);
            //窗体控制
            this.WindowState = FormWindowState.Maximized;
            axTOCControl1.SetBuddyControl(axMapControl1);
            axToolbarControl1.SetBuddyControl(axMapControl1);
            //显示票数
            Buy b = new Buy();
            b.Lbl_rw = lbl_rw;
            b.Lbl_yw = lbl_yw;
            b.Lbl_yz = lbl_yz;
            b.Lbl_wz = lbl_wz;
            b.show();

            cbo_type.SelectedItem = 3;
        }
        //实例化GeoMapAO，导入shp文件1
        private void shapefileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //加载地图数据
            //手动选择
            //OpenFileDialog OpenDlg = new OpenFileDialog();
            //OpenDlg.Title = "请选择地理数据文件";
            //OpenDlg.Filter = "矢量数据文件(*.shp)|*.shp";
            //OpenDlg.Multiselect = true;//可以多选
            //OpenDlg.ShowDialog();
            //string[] strFileName = OpenDlg.FileNames;
            string[] strFileName = { @"D:\MyData\GIS\K1067\District.shp",
            @"D:\MyData\GIS\K1067\Province.shp",
            @"D:\MyData\GIS\K1067\Water.shp",
            @"D:\MyData\GIS\K1067\K1067.shp",
            @"D:\MyData\GIS\K1067\Station.shp",
            @"D:\MyData\GIS\K1067\T.shp"};
            if (strFileName.Length > 0)
            {
                IAddGeoData pAddGeoData = new GeoMapAO();//实例化对象
                pAddGeoData.StrFileName = strFileName;
                pAddGeoData.AxMapControl1 = axMapControl1;
                pAddGeoData.AxMapControl2 = axMapControl2;
                pAddGeoData.AddGeoMap();
            }
        }
        //退出程序
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //拉框放大显示
        private void axMapControl1_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            //拉框放大显示
            if (GeoOpType == string.Empty)
                return;
            IGeoDataOper pGeoMapOp = new GeoMapAO();
            pGeoMapOp.StrOperType = GeoOpType;
            pGeoMapOp.AxMapControl1 = axMapControl1;
            pGeoMapOp.AxMapControl2 = axMapControl2;
            pGeoMapOp.E = e;
            pGeoMapOp.OperMap();
        }

        //调用Identify模块，双击识别要素
        private void axMapControl1_OnDoubleClick(object sender, IMapControlEvents2_OnDoubleClickEvent e)
        {
            Identify i = new Identify();
            i.E = e;
            i.AxMapControl1 = axMapControl1;
            i.Iddd();
        }
        //打开属性查询窗口
        private void selectByAttributesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQueryByAttribute newQueryByAttribute = new frmQueryByAttribute(axMapControl1.Map);
            newQueryByAttribute.Show();
        }
        //查票价
        private void btn_check_Click(object sender, EventArgs e)
        {
            Check c = new Check();
            c.Cbo_type = cbo_type;
            c.Txt_from = txt_from;
            c.Txt_to = txt_to;
            c.fare();
        }
        //保存时间表
        private void btn_timetable_Click(object sender, EventArgs e)
        {
            Excel ex = new Excel();
            ex.DGV = dataGridView1;
            ex.output();
        }
        //购票
        private void btn_buy_Click(object sender, EventArgs e)
        {
            Buy b = new Buy();
            b.Lbl_rw = lbl_rw;
            b.Lbl_yw = lbl_yw;
            b.Lbl_yz = lbl_yz;
            b.Lbl_wz = lbl_wz;
            b.Cbo_type = cbo_type;
            b.buy();
        }
        //K1067
        private void button1_Click(object sender, EventArgs e)
        {
            //注册按钮的单击事件
            //数据库连接串
            string connStr = "Data Source=.;Initial Catalog=railway;User ID=sa;Password=20001217";
            //创建SQLConnection的实例
            SqlConnection conn = null;
            try
            {
                string m = "";
                conn = new SqlConnection(connStr);
                //打开数据库连接
                conn.Open();
                string sql = "select * from K1067";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    m += r[0].ToString() + " " + r[1].ToString() + " " + r[2].ToString() + " " + r[3].ToString() + " " + r[4].ToString() + "\n";
                }
                MessageBox.Show(m);
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询失败！" + ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    //关闭数据库连接
                    conn.Close();
                }
            }
        }
        //机务运用
        private void button2_Click(object sender, EventArgs e)
        {
            //数据库连接串
            string connStr = "Data Source=.;Initial Catalog=railway;User ID=sa;Password=20001217";
            //创建SQLConnection的实例
            SqlConnection conn = null;
            try
            {
                string m = "";
                conn = new SqlConnection(connStr);
                //打开数据库连接
                conn.Open();
                string sql = "select * from locomotive";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    m += r[0].ToString() + " " + r[1].ToString() + " " + r[2].ToString() + " " + r[3].ToString() + "\n";
                }
                MessageBox.Show(m);
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询失败！" + ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    //关闭数据库连接
                    conn.Close();
                }
            }
        }
        //获取北京时间
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_time.Text = "当前时间：" + DateTime.Now.ToString();
        }
    }
}
