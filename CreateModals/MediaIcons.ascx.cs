using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using umbraco.cms.businesslogic.media;
using umbraco.BusinessLogic;
using umbraco.BasePages;

namespace CreateModals
{
    public partial class MediaIcons : System.Web.UI.UserControl
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            int parentNodeID = Convert.ToInt32(HttpContext.Current.Request.QueryString["nodeid"]);

            if (IsPostBack)
            {
                Media media = Media.MakeNew(name.Value, new MediaType(Convert.ToInt32(mediaTypeID.Value)), User.GetCurrent(), parentNodeID);

                string returnUrl = "editMedia.aspx?id=" + media.Id + "&isNew=true";
                BasePage.Current.ClientTools.ChangeContentFrameUrl(returnUrl).CloseModalWindow();
            }
            else
            {
                List<MediaType> MediaTypes = new List<MediaType>() { };

                if (parentNodeID == -1)
                {
                    foreach (MediaType mt in MediaType.GetAllAsList())
                    {
                        MediaTypes.Add(mt);
                    }
                }
                else
                {
                    Media parentMedia = new Media(parentNodeID);

                    foreach (int mediaTypeID in parentMedia.ContentType.AllowedChildContentTypeIDs)
                    {
                        MediaType mt = new MediaType(Convert.ToInt32(mediaTypeID));
                        MediaTypes.Add(mt);
                    }
                }

                if (MediaTypes.Count == 0)
                {
                    header.Visible = false;
                    createButton.Visible = false;

                    HtmlGenericControl div = new HtmlGenericControl("div");
                    div.InnerHtml = "There are no media types available to be made under this media item.";
                    mediaTypeWrapper.Controls.Add(div);
                    return;
                }

                MediaTypes = MediaTypes.OrderBy(o => o.Text).ToList();

                foreach (MediaType mt in MediaTypes)
                {
                    HtmlGenericControl mtDiv;
                    HtmlGenericControl div;
                    HtmlGenericControl img;

                    mtDiv = new HtmlGenericControl("div");
                    mtDiv.Attributes["class"] = "mediaType";
                    mtDiv.Attributes["rel"] = mt.Id.ToString();
                    mediaTypeWrapper.Controls.Add(mtDiv);

                    img = new HtmlGenericControl("img");
                    img.Attributes["src"] = "/umbraco/images/thumbnails/" + mt.Thumbnail;
                    img.Attributes["class"] = "large";
                    mtDiv.Controls.Add(img);

                    img = new HtmlGenericControl("img");
                    img.Attributes["src"] = "/umbraco/images/umbraco/" + mt.IconUrl;
                    img.Attributes["class"] = "small";
                    mtDiv.Controls.Add(img);

                    div = new HtmlGenericControl("div");
                    div.Attributes["class"] = "mediaTypeTitle";
                    div.InnerHtml = mt.Text;
                    mtDiv.Controls.Add(div);

                    div = new HtmlGenericControl("div");
                    div.Attributes["class"] = "mediaTypeDescription";
                    div.InnerHtml = mt.Description;
                    mtDiv.Controls.Add(div);
                }
            }        
        }
    }
}