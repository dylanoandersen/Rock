// <copyright>
// Copyright by the Spark Development Network
//
// Licensed under the Rock Community License (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.rockrms.com/license
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//
using System;
using System.ComponentModel;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

using Rock;
using Rock.Data;
using Rock.Attribute;
using Rock.Model;

using DocumentFormat.OpenXml.Packaging;
using System.Collections.Generic;

namespace RockWeb.Plugins.org_rocksolidchurch.Tutorials
{
    [RockObsolete("1.16.7")]
    [Obsolete("This block type has been deprecated.")]

    [DisplayName("Task1")]
    [Category("rocksolidchurch > Tutorials")]
    [Description("Trying to fetch data")]

    [LinkedPage("Detail Page", Order = 0)]


    #region Block Attributes

    [BooleanField(
        "Show Email Address",
        Key = AttributeKey.ShowEmailAddress,
        Description = "Should the email address be shown?",
        DefaultBooleanValue = true,
        Order = 1)]

    [EmailField(
        "Email",
        Key = AttributeKey.Email,
        Description = "The Email address to show.",
        DefaultValue = "ted@rocksolidchurchdemo.com",
        Order = 2)]

    #endregion Block Attributes
    [Rock.SystemGuid.BlockTypeGuid("D6B14847-B652-49E2-9D4B-658D502F0AEC")]
    public partial class Task1 : Rock.Web.UI.RockBlock
    {

        #region Attribute Keys

        private static class AttributeKey
        {
            public const string ShowEmailAddress = "ShowEmailAddress";
            public const string Email = "Email";
        }

        public string DetailPage => this.GetAttributeValue("DetailPage");


        #endregion Attribute Keys

        #region PageParameterKeys

        private static class PageParameterKey
        {
            public const string StarkId = "StarkId";
        }

        #endregion PageParameterKeys

        #region Fields

        // Used for private variables.

        #endregion

        #region Properties

        // Used for public / protected properties.

        #endregion

        #region Base Control Methods

        // Overrides of the base RockBlock methods (i.e. OnInit, OnLoad)

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Init" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> object that contains the event data.</param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            // This event gets fired after block settings are updated. It's nice to repaint the screen if these settings would alter it.
            this.BlockUpdated += Block_BlockUpdated;
            this.AddConfigurationUpdateTrigger(upnlContent);

            gPeople.RowSelected += gPeople_RowSelected;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Load" /> event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.EventArgs" /> object that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if( !Page.IsPostBack)
            {
                var item = new GroupService(new RockContext()).Queryable().Where(g => g.IsActive == true && g.GroupTypeId == 25).ToList();
                gPeople.DataSource = item;
                gPeople.DataBind();
            }
        }

        protected void gPeople_RowSelected(object sender, Rock.Web.UI.Controls.RowEventArgs e)
        {
            int groupId = (int)e.RowKeyId;
            Guid task1DetailsPageGuid = new Guid("757fac9a-f21e-47ab-a821-6cf1583ba019");
            NavigateToPage(task1DetailsPageGuid, new Dictionary<string, string> { { "GroupId", groupId.ToString() } });
        }

        #endregion

        #region Events

        // Handlers called by the controls on your block.

        /// <summary>
        /// Handles the BlockUpdated event of the control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Block_BlockUpdated(object sender, EventArgs e)
        {

        }

        #endregion

        #region Methods

        // helper functional methods (like BindGrid(), etc.)

        #endregion
    }
}