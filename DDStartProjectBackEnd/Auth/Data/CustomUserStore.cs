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
    public class CustomUserStore : IUserStore<User>, IUserPasswordStore<User>, IDisposable, IUserEmailStore<User>
    {
        private readonly IDbConnection _dbConnection;
        private readonly SqlHelper<CustomUserStore> _sqlHelper;

        public CustomUserStore(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
            _sqlHelper = new SqlHelper<CustomUserStore>();
        }

        public async Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
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

        public async Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
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

        public async Task<User> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            var query = _sqlHelper.GetSql();

            using var conn = _dbConnection.GetConnection;
            var param = new DynamicParameters();
            param.Add(
                "@NormalizedEmail", normalizedEmail);

            var user = await conn.QuerySingleOrDefaultAsync<User>(query, param: param, commandType: CommandType.Text);

            return user;
        }

        public async Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            using var conn = _dbConnection.GetConnection;
            var query = _sqlHelper.GetSql();

            var param = new DynamicParameters();
            param.Add("@Id", userId);
            return await conn.QueryFirstOrDefaultAsync<User>(query, param: param, commandType: CommandType.Text);
        }

        public async Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            using var conn = _dbConnection.GetConnection;
            var query = _sqlHelper.GetSql();

            var param = new DynamicParameters();
            param.Add("@normalizedUserName", normalizedUserName);

            return await conn.QueryFirstOrDefaultAsync<User>(query, param: param, commandType: CommandType.Text);
        }

        public async Task<string> GetEmailAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));
            return await Task.Run(() => user.Email);
        }

        public async Task<bool> GetEmailConfirmedAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));
            return await Task.Run(() => user.EmailConfirmed);
        }

        public async Task<string> GetNormalizedEmailAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));
            return await Task.Run(() => user.Email.ToUpper());
        }

        public async Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));
            return await Task.Run(() => user.UserName.ToUpper());
        }

        public async Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));
            return await Task.Run(() => user.PasswordHash);
        }

        public async Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));
            return await Task.Run(() => user.Id.ToString());
        }

        public async Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));
            return await Task.Run(() => user.UserName);
        }

        public Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));
            return Task.FromResult(!string.IsNullOrWhiteSpace(user.PasswordHash));
        }

        public Task SetEmailAsync(User user, string email, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));
            user.Email = email;
            return Task.FromResult<object>(null);
        }

        public Task SetEmailConfirmedAsync(User user, bool confirmed, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));
            user.EmailConfirmed = confirmed;
            return Task.FromResult<object>(null);
        }

        public Task SetNormalizedEmailAsync(User user, string normalizedEmail, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));
            user.NormalizedEmail = normalizedEmail;
            return Task.FromResult<object>(null);
        }

        public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));
            user.NormalizedUserName = normalizedName;
            return Task.FromResult<object>(null);
        }

        public Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));
            user.PasswordHash = passwordHash;
            return Task.FromResult<object>(null);
        }

        public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));
            user.UserName = userName;
            return Task.FromResult<object>(null);
        }

        public async Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
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