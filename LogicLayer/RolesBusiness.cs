using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using carrentalservice.Models;
using carrentalservice.LogicLayer;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace carrentalservice.LogicLayer
{
    public class RolesBusiness
    {
        ApplicationDbContext con = new ApplicationDbContext();
        UserManager<ApplicationUser> UserManger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
        RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

        public bool AddUserToRoleTwo(string rolename, string username)
        {
            try
            {
                ApplicationUser user = UserManger.FindByName(username);
                IdentityRole role = roleManager.FindByName(rolename);

                if (!UserManger.IsInRole(user.Id, rolename))
                {
                    UserManger.AddToRole(user.Id, rolename);

                }
                return true;
            }
            catch
            {
                return false;
            }

        }

        public void AddUserToRole(string userid, string rolename)
        {
            var exists = FindRoleAndCreate(role: rolename);
            UserManger.AddToRole(userId: userid, role: rolename);
        }




        public bool IsUserInRole(string userid, string roleid)
        {
            return UserManger.IsInRole(userId: userid, role: roleid);
        }

        public List<UsersView> UsersInRole(string roleId)
              {

                 var role = con.Roles.ToList().Where(predicate: x => x.Name == roleId).FirstOrDefault();

                 var list = con.Roles.ToList().Where(predicate: x => x.Id == role.Id).ToList();

                 List<UsersView> ulist = new List<UsersView>();

                 foreach (var uir in list)
                 {
                     var user = UserManger.Users.ToList().Where(predicate: x => x.Id == uir.Id).FirstOrDefault();

                     ulist.Add(item: new UsersView
                     {
                         UserId = user.Id,
                         Name = user.Email
                     });
                 }

                 return ulist;
              }


        public bool CreateRole(string name)
        {
            var idResult = roleManager.Create(role: new IdentityRole(roleName: name));
            return idResult.Succeeded;
        }

        public bool FindRoleAndCreate(string role)
        {
            var exists = roleManager.FindByName(roleName: role);

            if (exists != null)
            {
                return true;
            }

            else
            {
                CreateRole(name: role);
                return false;
            }
        }

        public bool RemoveUserFromRole(string rolename, string username)
        {
            try
            {
                ApplicationUser user = UserManger.FindByName(username);

                IdentityRole role = roleManager.FindByName(rolename);
                if (!UserManger.IsInRole(user.Id, rolename))
                {
                    UserManger.RemoveFromRoleAsync(user.Id, rolename);

                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<IdentityRole> getdata()
        {
            return roleManager.Roles.ToList();
        }

        public List<RolesViewModel> getall()
        {
            return getdata().Select(x => new RolesViewModel
            {
                RoleName = x.Name,

            }).ToList();
        }

        public RolesViewModel FindByName(string name)
        {
            return getall().SingleOrDefault(x => x.RoleName.Equals(name));
        }
    }
}
