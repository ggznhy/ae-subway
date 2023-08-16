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

namespace WAEngine
{
    //管理控件的接口
    interface IComControl
    {
        //主视图控件
        AxMapControl AxMapControl1
        {
            get; set;
        }
        //鹰眼视图控件
        AxMapControl AxMapControl2
        {
            get; set;
        }
        //版面视图控件
        AxPageLayoutControl AxPageLayoutControl
        {
            get; set;
        }
        //定义设置颜色的方法
        IRgbColor GetRGB(int r, int g, int b);
    }

    //管理地理数据加载的接口
    interface IAddGeoData : IComControl
    {
        //存放用户选择的地理数据文件
        string[] StrFileName { get; set; }
        //加载地理数据的方法
        void AddGeoMap();
    }
    //管理地图操作的接口
    interface IGeoDataOper : IComControl
    {
        //地图操作的类型
        string StrOperType { get; set; }
        //鼠标按下事件的参数
        IMapControlEvents2_OnMouseDownEvent E { get; set; }
        void OperMap();
    }
    class GeoMapAO : IAddGeoData, IGeoDataOper
    {
        //实现地图控件的接口
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

        AxMapControl axMapControl2;
        public AxMapControl AxMapControl2
        {
            get
            {
                return axMapControl2;
            }

            set
            {
                axMapControl2 = value;
            }
        }

        AxPageLayoutControl axPageLayoutControl1;
        public AxPageLayoutControl AxPageLayoutControl
        {
            get
            {
                return axPageLayoutControl1;
            }

            set
            {
                axPageLayoutControl1 = value;
            }
        }
        public IRgbColor GetRGB(int r, int g, int b)
        {
            IRgbColor pColor = new RgbColorClass();
            pColor.Red = r;
            pColor.Green = g;
            pColor.Blue = b;
            return pColor;
        }

        string[] strFileName;
        public string[] StrFileName
        {
            get
            {
                return strFileName;
            }

            set
            {
                strFileName = value;
            }
        }

        public void AddGeoMap()
        {
            for (int i = 0; i < strFileName.Length; i++)
            {
                string strExt = System.IO.Path.GetExtension(strFileName[i]);
                switch (strExt)//判断文件类型，然后采用不同的方式加载文件
                {
                    case ".shp"://用户选择了矢量格式的地理数据
                        {
                            string strPath = System.IO.Path.GetDirectoryName(strFileName[i]);
                            string strFile = System.IO.Path.GetFileNameWithoutExtension(strFileName[i]);
                            //向控件加载地图
                            axMapControl1.AddShapeFile(strPath, strFile);
                            axMapControl2.AddShapeFile(strPath, strFile);
                            axMapControl2.Extent = axMapControl2.FullExtent;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        //实现鼠标与地图交互的接口
        string strOperType;
        public string StrOperType
        {
            get
            {
                return strOperType;
            }

            set
            {
                strOperType = value;
            }
        }

        //定义鼠标按下事件的变量
        IMapControlEvents2_OnMouseDownEvent e;
        public IMapControlEvents2_OnMouseDownEvent E
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
        //定义鼠标与地图交互的方法
        public void OperMap()
        {
            switch (strOperType)
            {
                case "LKZoomIn":
                    {
                        axMapControl1.Extent = axMapControl1.TrackRectangle();
                        axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
