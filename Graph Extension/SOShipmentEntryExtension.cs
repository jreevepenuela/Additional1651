using PX.Data;
using PX.Objects.CS;
using PX.Objects.IN;
using PX.Objects.SO;
using System;

namespace Additional1651
{
    public class SOShipmentEntryExtension : PXGraphExtension<SOShipmentEntry>
    {
        private const string Message = "Shipment Type Cannot Be null";

        #region Event Handlers

        protected void _(Events.RowPersisting<SOShipment> e)
        {

            int? lastnum = 0;

            foreach (SOShipment rows in Base.Document.Cache.Cached)
            {
                PXCache cache = Base.Document.Cache;
                var newew = rows.ShipmentNbr;
                var rowsExt = PXCache<SOShipment>.GetExtension<SOShipmentExtension>(rows);
                var cunbr = rowsExt.UsrShipmentNBrs;

                if (newew == " <NEW>" || cunbr == 1)
                {
                    var gettypes = rowsExt.Usrshipmenttypee;

                    if (gettypes == null)
                    {

                    }
                    else if (gettypes == "DR")
                    {
                        foreach (SOShipment ress in PXSelect<SOShipment, Where<SOShipmentExtension.usrshipmenttypee, Equal<Required<SOShipmentExtension.usrshipmenttypee>>>>.Select(Base, "DR"))
                        {
                            if (ress != null)
                            {
                                SOShipmentExtension ressext = PXCache<SOShipment>.GetExtension<SOShipmentExtension>(ress);

                                if (ressext.UsrShipmentNBrs == null)
                                    lastnum = 100000;
                                else
                                {
                                    if (Convert.ToInt32(ressext.UsrShipmentNBrs) == lastnum)
                                        lastnum = Convert.ToInt32(ressext.UsrShipmentNBrs);
                                    else if (Convert.ToInt32(ressext.UsrShipmentNBrs) > lastnum)
                                        lastnum = Convert.ToInt32(ressext.UsrShipmentNBrs);
                                }
                            }
                        }
                    }
                    else if (gettypes == "AR")
                    {
                        foreach (SOShipment ress in PXSelect<SOShipment, Where<SOShipmentExtension.usrshipmenttypee, Equal<Required<SOShipmentExtension.usrshipmenttypee>>>>.Select(Base, "AR"))
                        {
                            if (ress != null)
                            {
                                SOShipmentExtension ressext = PXCache<SOShipment>.GetExtension<SOShipmentExtension>(ress);

                                if (ressext.UsrShipmentNBrs == null)
                                    lastnum = 100000;
                                else
                                {
                                    if (Convert.ToInt32(ressext.UsrShipmentNBrs) == lastnum)
                                        lastnum = Convert.ToInt32(ressext.UsrShipmentNBrs);
                                    else if (Convert.ToInt32(ressext.UsrShipmentNBrs) > lastnum)
                                        lastnum = Convert.ToInt32(ressext.UsrShipmentNBrs);
                                }
                            }
                        }

                    }
                }

                cache.SetValue<SOShipmentExtension.usrShipmentNBrs>(rows, lastnum + 1);
            }
            foreach (SOShipment rowss in Base.Document.Cache.Cached)
            {
                var rowssExt = PXCache<SOShipment>.GetExtension<SOShipmentExtension>(rowss);

                if (rowssExt.Usrshipmenttypee == null && rowss.Status == "N")
                    // Acuminator disable once PX1051 NonLocalizableString [Justification]
                    throw new PXException(Message);
            }

        }

        protected void SOShipment_RowSelected(PXCache cache, PXRowSelectedEventArgs e)
        {

            var row = (SOShipment)e.Row;

            PXUIFieldAttribute.SetEnabled<SOShipmentExtension.usrTruckNo2>(cache, e.Row, true);
            foreach (SOShipment rows in Base.Document.Cache.Cached)
            {
                PXCache cache1 = Base.Document.Cache;
                var rowsExt = PXCache<SOShipment>.GetExtension<SOShipmentExtension>(rows);
                var getnoo = rowsExt.UsrShipmentNBrs;
                var gettype = rowsExt.Usrshipmenttypee;
                var finalnobr = rowsExt.Usrfinalshipnbr;

                if (getnoo != null && gettype != null)
                {
                    var finalval = gettype + getnoo;
                    cache1.SetValue<SOShipmentExtension.usrfinalshipnbr>(rows, finalval);
                }

                if (finalnobr == null)
                    cache1.SetValue<SOShipmentExtension.usrfinalshipnbr>(rows, " <NEW>");

                if (finalnobr == " <NEW>" || finalnobr == null)
                    PXUIFieldAttribute.SetEnabled<SOShipmentExtension.usrshipmenttypee>(cache, e.Row, true);
                else
                    PXUIFieldAttribute.SetEnabled<SOShipmentExtension.usrshipmenttypee>(cache, e.Row, false);
            }
        }

        public delegate Boolean CreateShipmentFromSchedulesDelegate(PXResult<SOShipmentPlan,
            SOLineSplit, SOLine, InventoryItem, INLotSerClass, INSite, SOShipLine>
                res, SOShipLine newline, SOOrderType ordertype, String operation, DocumentList<SOShipment> list);
        [PXOverride]
        public bool CreateShipmentFromSchedules(
            PXResult<SOShipmentPlan, SOLineSplit, SOLine, InventoryItem, INLotSerClass, INSite, SOShipLine> res,
            SOShipLine newline, SOOrderType ordertype, string operation, DocumentList<SOShipment> list,
            CreateShipmentFromSchedulesDelegate del)
        {
            SOLine line = (SOLine)res;
            PXFieldDefaulting specialistFieldDefaulting = new PXFieldDefaulting((s, a) =>
            {
                if (line != null)
                {
                    a.NewValue = line.GetExtension<SOLineExtension>().UsrCustomerLocation;
                    a.Cancel = true;
                }
            });

            bool result;
            Base.FieldDefaulting.AddHandler<SOShipLineExtension.usrCustomLocation>(specialistFieldDefaulting);
            try
            {
                result = del(res, newline, ordertype, operation, list);
            }
            finally
            {
                Base.FieldDefaulting.RemoveHandler<SOShipLineExtension.usrCustomLocation>(specialistFieldDefaulting);
            }
            return result;
        }

        #region PersistDelegate
        //public delegate void PersistDelegate();
        //[PXOverride]
        //public void Persist(PersistDelegate baseMethod)
        //{
        //    var lastnum = 0;

        //    foreach (SOShipment rows in Base.Document.Cache.Cached)
        //    {
        //        PXCache cache = Base.Document.Cache;
        //        var newew = rows.ShipmentNbr;
        //        var rowsExt = PXCache<SOShipment>.GetExtension<SOShipmentExt>(rows);
        //        var cunbr = rowsExt.UsrShipmentNBrs;

        //        if (newew == " <NEW>" || cunbr == "1")
        //        {
        //            var gettypes = rowsExt.Usrshipmenttypee;

        //            if (gettypes == null)
        //            {

        //            }
        //            else if (gettypes == "DR")
        //            {
        //                foreach (SOShipment ress in PXSelect<SOShipment, Where<SOShipmentExt.usrshipmenttypee, Equal<Required<SOShipmentExt.usrshipmenttypee>>>>.Select(Base, "DR"))
        //                {
        //                    if (ress != null)
        //                    {
        //                        SOShipmentExt ressext = PXCache<SOShipment>.GetExtension<SOShipmentExt>(ress);

        //                        if (ressext.UsrShipmentNBrs == null)
        //                            lastnum = 100000;
        //                        else
        //                        {
        //                            if (Convert.ToInt32(ressext.UsrShipmentNBrs) == lastnum)
        //                                lastnum = Convert.ToInt32(ressext.UsrShipmentNBrs);
        //                            else if (Convert.ToInt32(ressext.UsrShipmentNBrs) > lastnum)
        //                                lastnum = Convert.ToInt32(ressext.UsrShipmentNBrs);
        //                        }
        //                    }
        //                }
        //            }
        //            else if (gettypes == "AR")
        //            {
        //                foreach (SOShipment ress in PXSelect<SOShipment, Where<SOShipmentExt.usrshipmenttypee, Equal<Required<SOShipmentExt.usrshipmenttypee>>>>.Select(Base, "AR"))
        //                {
        //                    if (ress != null)
        //                    {
        //                        SOShipmentExt ressext = PXCache<SOShipment>.GetExtension<SOShipmentExt>(ress);

        //                        if (ressext.UsrShipmentNBrs == null)
        //                            lastnum = 100000;
        //                        else
        //                        {
        //                            if (Convert.ToInt32(ressext.UsrShipmentNBrs) == lastnum)
        //                                lastnum = Convert.ToInt32(ressext.UsrShipmentNBrs);
        //                            else if (Convert.ToInt32(ressext.UsrShipmentNBrs) > lastnum)
        //                                lastnum = Convert.ToInt32(ressext.UsrShipmentNBrs);
        //                        }
        //                    }
        //                }

        //            }
        //        }

        //        var aa = lastnum + 1;
        //        var ww = aa.ToString();
        //        cache.SetValue<SOShipmentExt.usrShipmentNBrs>(rows, ww);
        //    }
        //    foreach (SOShipment rowss in Base.Document.Cache.Cached)
        //    {
        //        var rowssExt = PXCache<SOShipment>.GetExtension<SOShipmentExt>(rowss);

        //        if (rowssExt.Usrshipmenttypee == null && rowss.Status == "N")
        //            throw new PXException(Message);
        //        else
        //            baseMethod();
        //    }
        //}
        #endregion

        #endregion
    }
}
