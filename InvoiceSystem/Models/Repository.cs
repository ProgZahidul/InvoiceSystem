using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceSystem.Models
{
    public class Repository
    {
        static List<InvoiceInfo> invocieinfo = new List<InvoiceInfo>();
        public Repository() 
        {
            if(invocieinfo.Count == 0)
                for(int i=1; i <=3; i++)
                {
                    InvoiceInfo info = new InvoiceInfo();
                    info.Name="Coustomer"+i.ToString();
                    info.Address="Address"+i.ToString();
                    info.Prducts.Add(new ProductInfo()
                    {
                        PrductName = "Prduct 1",
                        UnitPrice = 300,
                        Quantity = 2
                    });
                    info.Prducts.Add(new ProductInfo()
                    {
                        PrductName = "Prduct 2",
                        UnitPrice = 300,
                        Quantity = 2,
                        
                    });
                    
                    invocieinfo.Add(info);
                }
        }
        public List<InvoiceInfo> GetList()
        {
            return invocieinfo;
        }
        public InvoiceInfo Get(Guid id)
        {
            return invocieinfo.Find(m=> m.Id == id);
        }
        internal void Update (InvoiceInfo upinfo)
        {
            var data=invocieinfo.FindIndex(m=>m.Id == upinfo.Id);
             invocieinfo[data] = upinfo;
        }
        internal void Delete(InvoiceInfo dltinfo)
        {
            var dlt=invocieinfo.FindIndex(m=> m.Id==dltinfo.Id);
            invocieinfo.RemoveAt(dlt);
        }
        internal void Save(InvoiceInfo invoiceinfo)
        {
            invocieinfo.Add(invoiceinfo);
        }
    }
}