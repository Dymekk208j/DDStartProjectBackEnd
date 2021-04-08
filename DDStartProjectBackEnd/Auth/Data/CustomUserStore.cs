using Dapper;
using DDStartProjectBackEnd.Auth.Models;
using DDStartProjectBackEnd.Common.Helpers;
using Microsoft.AspNetCore.Identity;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using IDbConnection = DDStartProjectBackEnd.Common.Helpers.IDbConnection;

namespace DDStartProjectBackEnd.Auth.Data
{
    public class CustomUserStore : IUserStore<ApplicationUserIdentity>, IUserPasswordStore<ApplicationUserIdentity>, IDisposable, IUserEmailStore<ApplicationUserIdentity>
    {
        private readonly IDbConnection _dbConnection;
        private readonly SqlHelper<CustomUserStore> _sqlHelper;

        public CustomUserStore(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
            _sqlHelper = new SqlHelper<CustomUserStore>();
        }

        public async Task<IdentityResult> CreateAsync(ApplicationUserIdentity user, CancellationToken cancellationToken)
        {
            using var conn = _dbConnection.GetConnection;
            var query = _sqlHelper.GetSql();

            var param = new DynamicParameters();
            param.Add("@Id", user.Id);
            param.Add("@UserName", user.UserName);
            param.Add("@NormalizedUserName", user.NormalizedUserName);
            param.Add("@Email", user.Email);
            param.Add("@NormalizedEmail", string.IsNullOrEmpty(user.Email) ? null : user.Email.ToUpper());
            param.Add("@EmailConfirmed", user.EmailConfirmed);
            param.Add("@PasswordHash", user.PasswordHash);
            param.Add("@SecurityStamp", user.SecurityStamp);
            param.Add("@ConcurrencyStamp", user.ConcurrencyStamp);
            param.Add("@PhoneNumber", user.PhoneNumber);
            param.Add("@PhoneNumberConfirmed", user.PhoneNumberConfirmed);
            param.Add("@TwoFactorEnabled", user.TwoFactorEnabled);
            param.Add("@LockoutEnd", user.LockoutEnd);
            param.Add("@LockoutEnabled", user.LockoutEnabled);
            param.Add("@AccessFailedCount", user.AccessFailedCount);
            param.Add("@Firstname", user.Firstname);
            param.Add("@Lastname", user.Lastname);
            param.Add("@Gender", user.Gender);

            var result = await conn.ExecuteAsync(query, param: param, commandType: CommandType.Text);

            if (result > 0)
                return IdentityResult.Success;
            else
                return IdentityResult.Failed(new IdentityError() { Code = "120", Description = "Cannot Create User!" });
        }

        public async Task<IdentityResult> DeleteAsync(ApplicationUserIdentity user, CancellationToken cancellationToken)
        {
            using var conn = _dbConnection.GetConnection;
            var query = _sqlHelper.GetSql();
            var param = new DynamicParameters();
            param.Add("@Id", user.Id);

            var result = await conn.ExecuteAsync(query, param: param, commandType: CommandType.Text);

            if (result > 0)
                return IdentityResult.Success;
            else
                return IdentityResult.Failed(new IdentityError() { Code = "120", Description = "Cannot Update User!" });
        }

        public void Dispose()
        {
            //Dispose();
        }

        public async Task<ApplicationUserIdentity> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            var query = _sqlHelper.GetSql();

            using var conn = _dbConnection.GetConnection;
            var param = new DynamicParameters();
            param.Add(
                "@NormalizedEmail", normalizedEmail);

            var user = await conn.QuerySingleOrDefaultAsync<ApplicationUserIdentity>(query, param: param, commandType: CommandType.Text);

            return user;
        }

        public async Task<ApplicationUserIdentity> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            using var conn = _dbConnection.GetConnection;
            var query = _sqlHelper.GetSql();

            var param = new DynamicParameters();
            param.Add("@Id", userId);
            return await conn.QueryFirstOrDefaultAsync<ApplicationUserIdentity>(query, param: param, commandType: CommandType.Text);
        }

        public async Task<ApplicationUserIdentity> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            using var conn = _dbConnection.GetConnection;
            var query = _sqlHelper.GetSql();

            var param = new DynamicParameters();
            param.Add("@normalizedUserName", normalizedUserName);

            return await conn.QueryFirstOrDefaultAsync<ApplicationUserIdentity>(query, param: param, commandType: CommandType.Text);
        }

        public async Task<string> GetEmailAsync(ApplicationUserIdentity user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));
            return await Task.Run(() => user.Email);
        }

        public async Task<bool> GetEmailConfirmedAsync(ApplicationUserIdentity user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));
            return await Task.Run(() => user.EmailConfirmed);
        }

        public async Task<string> GetNormalizedEmailAsync(ApplicationUserIdentity user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));
            return await Task.Run(() => user.Email.ToUpper());
        }

        public async Task<string> GetNormalizedUserNameAsync(ApplicationUserIdentity user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));
            return await Task.Run(() => user.UserName.ToUpper());
        }

        public async Task<string> GetPasswordHashAsync(ApplicationUserIdentity user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));
            return await Task.Run(() => user.PasswordHash);
        }

        public async Task<string> GetUserIdAsync(ApplicationUserIdentity user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));
            return await Task.Run(() => user.Id.ToString());
        }

        public async Task<string> GetUserNameAsync(ApplicationUserIdentity user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));
            return await Task.Run(() => user.UserName);
        }

        public Task<bool> HasPasswordAsync(ApplicationUserIdentity user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));
            return Task.FromResult(!string.IsNullOrWhiteSpace(user.PasswordHash));
        }

        public Task SetEmailAsync(ApplicationUserIdentity user, string email, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));
            user.Email = email;
            return Task.FromResult<object>(null);
        }

        public Task SetEmailConfirmedAsync(ApplicationUserIdentity user, bool confirmed, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));
            user.EmailConfirmed = confirmed;
            return Task.FromResult<object>(null);
        }

        public Task SetNormalizedEmailAsync(ApplicationUserIdentity user, string normalizedEmail, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));
            user.NormalizedEmail = normalizedEmail;
            return Task.FromResult<object>(null);
        }

        public Task SetNormalizedUserNameAsync(ApplicationUserIdentity user, string normalizedName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));
            user.NormalizedUserName = normalizedName;
            return Task.FromResult<object>(null);
        }

        public Task SetPasswordHashAsync(ApplicationUserIdentity user, string passwordHash, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));
            user.PasswordHash = passwordHash;
            return Task.FromResult<object>(null);
        }

        public Task SetUserNameAsync(ApplicationUserIdentity user, string userName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));
            user.UserName = userName;
            return Task.FromResult<object>(null);
        }

        public async Task<IdentityResult> UpdateAsync(ApplicationUserIdentity user, CancellationToken cancellationToken)
        {
            using var conn = _dbConnection.GetConnection;
            var query = _sqlHelper.GetSql();

            var param = new DynamicParameters();
            param.Add("@Id", user.Id);
            param.Add("@PasswordHash", user.PasswordHash);
            param.Add("@SecurityStamp", user.SecurityStamp);
            param.Add("@ConcurrencyStamp", user.ConcurrencyStamp);
            param.Add("@PhoneNumber", user.PhoneNumber);
            param.Add("@PhoneNumberConfirmed", user.PhoneNumberConfirmed);
            param.Add("@TwoFactorEnabled", user.TwoFactorEnabled);
            param.Add("@LockoutEnd", user.LockoutEnd);
            param.Add("@LockoutEnabled", user.LockoutEnabled);
            param.Add("@AccessFailedCount", user.AccessFailedCount);
            param.Add("@Firstname", user.Firstname);
            param.Add("@Lastname", user.Lastname);
            param.Add("@Gender", user.Gender);

            var result = await conn.ExecuteAsync(query, param: param, commandType: CommandType.Text);

            if (result > 0)
                return IdentityResult.Success;
            else
                return IdentityResult.Failed(new IdentityError() { Code = "120", Description = "Cannot Update User!" });
        }
    }
}