﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using umbraco.cms.businesslogic.web;
using umbraco.BasePages;
using umbraco.BusinessLogic;

namespace CreateModals
{
    public partial class ContentIcons : System.Web.UI.UserControl
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            int parentNodeID = Convert.ToInt32(HttpContext.Current.Request.QueryString["nodeid"]);

            if (IsPostBack)
            {
                Document document = Document.MakeNew(name.Value, new DocumentType(Convert.ToInt32(docTypeID.Value)), User.GetCurrent(), parentNodeID);

                string returnUrl = "editContent.aspx?id=" + document.Id + "&isNew=true";
                BasePage.Current.ClientTools.ChangeContentFrameUrl(returnUrl).CloseModalWindow();
            }
            else
            {
                List<DocumentType> docTypes = new List<DocumentType>() { };

                if (parentNodeID == -1)
                {
                    foreach (DocumentType dt in DocumentType.GetAllAsList())
                    {
                        docTypes.Add(dt);
                    }
                }
                else
                {

                    Document parentDocument = new Document(parentNodeID);

                    foreach (int docTypeID in parentDocument.ContentType.AllowedChildContentTypeIDs)
                    {
                        DocumentType dt = new DocumentType(docTypeID);
                        docTypes.Add(dt);
                    }
                }

                if (docTypes.Count == 0)
                {
                    header.Visible = false;
                    createButton.Visible = false;

                    HtmlGenericControl div = new HtmlGenericControl("div");
                    div.InnerHtml = "There are no document types available to be made under this document.";
                    docTypeWrapper.Controls.Add(div);
                    return;
                }

                docTypes = docTypes.OrderBy(o => o.Text).ToList();

                foreach (DocumentType dt in docTypes)
                {
                    HtmlGenericControl dtDiv;
                    HtmlGenericControl div;
                    HtmlGenericControl img;

                    dtDiv = new HtmlGenericControl("div");
                    dtDiv.Attributes["class"] = "docType";
                    dtDiv.Attributes["rel"] = dt.Id.ToString();
                    docTypeWrapper.Controls.Add(dtDiv);

                    img = new HtmlGenericControl("img");
                    img.Attributes["src"] = "/umbraco/images/thumbnails/" + dt.Thumbnail;
                    img.Attributes["class"] = "large";
                    dtDiv.Controls.Add(img);

                    img = new HtmlGenericControl("img");
                    img.Attributes["src"] = "/umbraco/images/umbraco/" + dt.IconUrl;
                    img.Attributes["class"] = "small";
                    dtDiv.Controls.Add(img);

                    div = new HtmlGenericControl("div");
                    div.Attributes["class"] = "docTypeTitle";
                    div.InnerHtml = dt.Text;
                    dtDiv.Controls.Add(div);

                    div = new HtmlGenericControl("div");
                    div.Attributes["class"] = "docTypeDescription";
                    div.InnerHtml = dt.Description;
                    dtDiv.Controls.Add(div);
                }
            }
        }
    }
}