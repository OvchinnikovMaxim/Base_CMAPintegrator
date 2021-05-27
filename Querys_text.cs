namespace CMAPIntegrator
{
    /// <summary>
    /// Основные тексты запросов
    /// </summary>
    class Querys_text
    {
        /// <summary>
        /// загрузка остатков
        /// </summary>
        public string ost = "SELECT kid, robj, vcnt,rscl FROM res";

        /// <summary>
        /// Количество загружаемой номенклатуры с остатками
        /// </summary>
        public string countOST = "SELECT COUNT(*) FROM res";

        #region выгрузка заказов
        /// <summary>
        /// наличие внутреннего ИД документа в КИС
        /// </summary>
        public string did = "SELECT did FROM mt_docs";

        /// <summary>
        /// наличие ИД шапки заказа
        /// </summary>
        public string master_kid = "SELECT master_kid FROM mt_docs";

        /// <summary>
        /// наличие ИД шапки заказа для табличной части
        /// </summary>
        public string rmaster_kid = "SELECT rmaster_kid FROM mt_details";

        /// <summary>
        /// добавление шапок заказов
        /// </summary>
        public string INS_docs_order = "INSERT INTO mt_docs (did, vdate, vshipping_date, vdiscont, vdist_client_id, vrem, rdoc_type, vdatecreate, rstate, fsend_kpk, fdel, ftrans, send) VALUES";

        /// <summary>
        /// помечание шапок заказов на удаление
        /// </summary>
        public string UPD_docs_order_del = "UPDATE mt_docs SET fdel=1 WHERE rdoc_type=1";

        /// <summary>
        /// обновление данных в шапке заказа
        /// </summary>
        public string UPD_docs_order = "UPDATE mt_docs SET fdel = 0";

        /// <summary>
        /// добавление табличной части заказов
        /// </summary>
        public string INS_det_order = "INSERT INTO mt_details (rmaster_kid, vdistr_obj, vamount, vcost_rub, vsum_rub, ftype  ) VALUES";

        /// <summary>
        /// ИД товарной позиции в КИС
        /// </summary>
        public string kid = "SELECT kid FROM mt_details";

        /// <summary>
        /// добавление новой товарной позиции в обновленном заказе
        /// </summary>
        public string INS_det_order_updDOC = "INSERT INTO mt_details (rmaster_kid, vdistr_obj, vamount, vcost_rub, vsum_rub, ftype  ) VALUES";

        /// <summary>
        /// помечание товарной позиции на удаление
        /// </summary>
        public string UPD_det_order_del = "UPDATE mt_details SET fdel=1";

        /// <summary>
        /// обновление данных в товарной позиции
        /// </summary>
        public string UPD_det_order = "UPDATE mt_details SET fdel=0";
        #endregion

        #region накладные
        /// <summary>
        /// запрос шапок накладных
        /// </summary>
        public string set_DOCS = "SELECT master_kid, vdate ,vdatecreate, rscl, vshipping_date, vdiscont, vrem, vdist_doc_number, did, vdist_client_id, vdistr_payer, rdoc FROM mt_docs";

        /// <summary>
        /// запрос деталей накладных
        /// </summary>
        public string set_DETS = "SELECT  d.did, d.vdist_doc_number, det.vdistr_obj, det.vamount, det.vcost, det.vcost_rub, det.vsum, det.vsum_rub, det.ftype FROM mt_details det JOIN mt_docs d ON d.master_kid=det.rmaster_kid";
        #endregion

        /// <summary>
        /// запрос контрагентов
        /// </summary>
        public string set_CLN = "SELECT nid, vname, vadres, vinn FROM cln";

        /// <summary>
        /// запрос номенклатуры
        /// </summary>
        public string set_OBJ = "SELECT kid, vname FROM obj";

        /// <summary>
        /// Количество загружаемых накладных
        /// </summary>
        public string countDocs = "SELECT COUNT(master_kid) FROM mt_docs WHERE rdoc_type=2";

        /// <summary>
        /// Количество загружаемых деталей в накладных
        /// </summary>
        public string countDetails = "SELECT COUNT(*) FROM mt_details where RMASTER_KID in (SELECT master_kid FROM mt_docs WHERE rdoc_type=2";

        /// <summary>
        /// Количество загружаемых контрагентов
        /// </summary>
        public string countCLN = "SELECT COUNT(*) FROM cln";

        /// <summary>
        /// Количество загружаемой номенклатуры
        /// </summary>
        public string countProd = "SELECT COUNT(*) FROM obj";
    }
}
