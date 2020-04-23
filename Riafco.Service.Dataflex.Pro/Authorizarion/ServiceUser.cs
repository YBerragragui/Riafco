using Riafco.Entity.Dataflex.Pro.Authorizarion;
using Riafco.Service.Dataflex.Pro.Authorizarion.Assembler;
using Riafco.Service.Dataflex.Pro.Authorizarion.Data;
using Riafco.Service.Dataflex.Pro.Authorizarion.Data.Enum;
using Riafco.Service.Dataflex.Pro.Authorizarion.Interface;
using Riafco.Service.Dataflex.Pro.Authorizarion.Request;
using Riafco.Service.Dataflex.Pro.Authorizarion.Response;
using Riafco.Service.Dataflex.Pro.UnitOfWork;
using System;
using System.Linq;

namespace Riafco.Service.Dataflex.Pro.Authorizarion
{
    /// <summary>
    /// The User service class.
    /// </summary>
    public class ServiceUser : IServiceUser
    {
        #region private attributes

        /// <summary>
        /// The UnitOfWork instance.
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region contructors
        /// <summary>
        /// Constructor to create instance of the _unitOfWork.
        /// </summary>
        /// <param name="injectedUnitOfWork">the injected UnitOfWork to instance UnitOfWork attribute.</param>
        public ServiceUser(IUnitOfWork injectedUnitOfWork)
        {
            if (injectedUnitOfWork == null)
            {
                throw new ArgumentNullException(nameof(injectedUnitOfWork));
            }
            _unitOfWork = injectedUnitOfWork;
        }
        #endregion

        #region public methods
        /// <summary>
        /// Create new User.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>User Response Pivot added.</returns>
        public UserResponsePivot CreateUser(UserRequestPivot request)
        {
            if (request?.UserPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            User user = request.UserPivot.ToEntity();
            _unitOfWork.UserRepository.Insert(user);
            _unitOfWork.Save();

            return new UserResponsePivot
            {
                UserPivot = user.ToPivot()
            };
        }

        /// <summary>
        /// Change User values.
        /// </summary>
        /// <param name="request">The User Request Pivot to change.</param>
        public void UpdateUser(UserRequestPivot request)
        {
            if (request?.UserPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            User user = _unitOfWork.UserRepository.GetById(request.UserPivot.UserId);
            if (!string.IsNullOrEmpty(request.UserPivot.UserPassword))
            {
                user.UserPassword = request.UserPivot.UserPassword;
            }
            user.UserMail = request.UserPivot.UserMail;
            user.UserName = request.UserPivot.UserName;
            if (request.UserPivot.UserPicture != null)
            {
                user.UserPicture = request.UserPivot.UserPicture;
            }
            _unitOfWork.Save();
        }

        /// <summary>
        /// Remove User.
        /// </summary>
        /// <param name="request">The User Request Pivot to remove.</param>
        public void DeleteUser(UserRequestPivot request)
        {
            if (request?.UserPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            User user = _unitOfWork.UserRepository.GetById(request.UserPivot.UserId);
            _unitOfWork.UserRepository.Delete(user);
            _unitOfWork.Save();
        }

        /// <summary>
        /// Get the list of the User.
        /// </summary>
        /// <returns>User Response Pivot response.</returns>
        public UserResponsePivot GetAllUsers()
        {
            return new UserResponsePivot
            {
                UserPivotList = _unitOfWork.UserRepository.Get().ToList().ToPivotList()
            };
        }

        /// <summary>
        /// Search User by id.
        /// </summary>
        /// <param name="request">The User Request Pivot to retrive.</param>
        /// <returns>User Response Pivot response.</returns>
        public UserResponsePivot FindUsers(UserRequestPivot request)
        {
            if (request?.UserPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            UserPivot result = new UserPivot();
            switch (request.FindUserPivot)
            {
                case FindUserPivot.UserId:
                    result = _unitOfWork.UserRepository.Get(c => c.UserId == request.UserPivot.UserId)?.FirstOrDefault().ToPivot();
                    break;
                case FindUserPivot.UserMail:
                    result = _unitOfWork.UserRepository.Get(c => c.UserMail == request.UserPivot.UserMail)?.FirstOrDefault().ToPivot();
                    break;
            }
            return new UserResponsePivot
            {
                UserPivot = result
            };
        }
        #endregion
    }
}