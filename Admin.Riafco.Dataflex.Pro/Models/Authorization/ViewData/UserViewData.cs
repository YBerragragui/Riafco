using Admin.Riafco.Dataflex.Pro.Models.Authorization.ItemData;
using System.Collections.Generic;

namespace Admin.Riafco.Dataflex.Pro.Models.Authorization.ViewData
{
    /// <summary>
    /// The UserViewData class. 
    /// </summary>
    public class UserViewData
    {
        /// <summary>
        /// Gets or sets Users
        /// </summary>
        public List<UserItemData> Users { get; set; }
    }
}