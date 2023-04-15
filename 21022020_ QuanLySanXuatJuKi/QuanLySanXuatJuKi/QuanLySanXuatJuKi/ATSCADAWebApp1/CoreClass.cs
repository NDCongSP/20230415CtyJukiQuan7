using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATSCADA.iWebTools;

namespace ATSCADAWebApp
{

    /// <summary>
    /// THIS CLASS IS FROM ATPROCORP, SHOULD NOT BE DELETED
    /// This class is for Setting Realtime Driver for all iWebTools controls
    /// </summary>
    public class SetDriver
    {
        public void SetDriverForiWebTools(ControlCollection controlCollection, List<Control> resultCollection, IDriverWeb Driver)
        {
            foreach (Control c in controlCollection)
            {
                //exclude iUpdatePanel - it has no Driver property
                if (c.GetType().ToString().Contains("ATSCADA.iWebTools"))

                {
                    try
                    {
                        resultCollection.Add(c);
                        ((IWebTool)c).Driver = Driver;
                    }
                    catch { }
                }
                if (c.HasControls())
                    SetDriverForiWebTools(c.Controls, resultCollection, Driver);
            }
        }
    }
    /// <summary>
    /// THIS CLASS IS FROM ATPROCORP, SHOULD NOT BE DELETED
    /// Realtime Driver, get data from WCF Client - Data is ported from iWebPort Winform Control
    /// </summary>
    public class iDriverWeb : IDriverWeb
    {
        public static ATWebPortServiceReference.InterfaceWebPortClient Driver = new ATWebPortServiceReference.InterfaceWebPortClient();
        public string GetTagValue(string TagName)
        {
            try
            {
                return Driver.GetTag(TagName).Value;
            }
            catch { return string.Empty; }
        }
        public string GetTagStatus(string TagName)
        {
            try
            {
                return Driver.GetTag(TagName).Status;
            }
            catch { return string.Empty; }
        }
        public void WriteTag(string TagName, string Value)
        {
            Driver.WriteTagValue(TagName, Value);
        }
    }

}