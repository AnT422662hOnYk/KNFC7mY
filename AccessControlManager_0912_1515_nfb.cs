// 代码生成时间: 2025-09-12 15:15:37
using System;
using System.Collections.Generic;

namespace AccessControl
{
    // Enum defining different user roles.
    public enum Role
    {
        Guest,
        User,
        Admin
    }

    // Interface defining a contract for classes that need to check access permissions.
    public interface IAccessControlled
    {
        bool CheckPermission(Role requiredRole);
    }

    // Static class managing access control logic.
    public static class AccessControlManager
    {
        // Dictionary to hold permissions for each role.
        private static readonly Dictionary<Role, HashSet<string>> rolePermissions = new Dictionary<Role, HashSet<string>>()
        {
            { Role.Guest, new HashSet<string> { "ViewContent" } },
            { Role.User, new HashSet<string> { "EditContent", "DeleteContent" } },
            { Role.Admin, new HashSet<string> { "ManageUsers", "EditContent", "DeleteContent", "ViewContent" } }
        };

        // Method to check if a user with a specific role has permission to perform an action.
        public static bool HasPermission(Role role, string permission)
        {
            if (!rolePermissions.ContainsKey(role))
            {
                // Handle the case where the role does not exist.
                Console.WriteLine($"Error: Role {role} is not recognized.");
                return false;
            }

            return rolePermissions[role].Contains(permission);
        }

        // Extension method for IAccessControlled to check permissions.
        public static bool CheckPermission(this IAccessControlled accessControlled, Role requiredRole)
        {
            return HasPermission(requiredRole, accessControlled.GetRequiredPermission());
        }
    }

    // Example class implementing IAccessControlled interface.
    public class DocumentEditor : IAccessControlled
    {
        // This method should be overridden to provide the specific permission required for the action.
        public string GetRequiredPermission()
        {
            return "EditContent";
        }
    }
}
