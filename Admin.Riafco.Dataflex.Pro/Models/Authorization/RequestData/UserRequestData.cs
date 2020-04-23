using Admin.Riafco.Dataflex.Pro.Models.Authorization.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.Authorization.ItemData.Enum;

namespace Admin.Riafco.Dataflex.Pro.Models.Authorization.RequestData
{
    /// <summary>
    /// The user request data.
    /// </summary>
    public class UserRequestData
    {
        /// <summary>
        /// Gets or sets user item data.
        /// </summary>
        public UserItemData UserDto { get; set; }

        /// <summary>
        /// Gets or sets FindUserItemDataEnum
        /// </summary>
        public FindUserItemData FindUserDto { get; set; }
    }
}