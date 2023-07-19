using Infraestructure.Repository.Interface;
using Infraestructure.Repository;
using Infraestructure.UnitOfWork.Interface;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore.Storage;
using Infraestructure.Entity.Models;

namespace Infraestructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        #region Attibutes
        private readonly DataContext _context;
        private bool disposed = false;


        #endregion


        #region MyRegion
        public UnitOfWork(DataContext dataContext)
        {
            _context = dataContext;
        }
        #endregion

        #region Properties       

        private IRepository<UserEntity> userRepository;
        private IRepository<RoleEntity> roleRepository;
        private IRepository<PermissionEntity> permissionRepository;
        private IRepository<PermissionTypeEntity> permissionTypeRepository;
        private IRepository<RolePermissionEntity> rolePermissionRepository;
        private IRepository<AuthorEntity> authorRepository;
        private IRepository<BookEntity> bookRepository;
        private IRepository<EditorialEntity> editorialRepository;

        #endregion

        #region Members

        public IRepository<UserEntity> UserRepository
        {
            get
            {
                if (this.userRepository == null)
                    this.userRepository = new Repository<UserEntity>(_context);
                return userRepository;
            }
        }

        public IRepository<RoleEntity> RoleRepository
        {
            get
            {
                if (this.roleRepository == null)
                    this.roleRepository = new Repository<RoleEntity>(_context);
                return roleRepository;
            }
        }

        public IRepository<PermissionEntity> PermissionRepository
        {
            get
            {
                if (this.permissionRepository == null)
                    this.permissionRepository = new Repository<PermissionEntity>(_context);
                return permissionRepository;
            }
        }

        public IRepository<PermissionTypeEntity> PermissionTypeRepository
        {
            get
            {
                if (this.permissionTypeRepository == null)
                    this.permissionTypeRepository = new Repository<PermissionTypeEntity>(_context);
                return permissionTypeRepository;
            }
        }

        public IRepository<RolePermissionEntity> RolePermissionRepository
        {
            get
            {
                if (this.rolePermissionRepository == null)
                    this.rolePermissionRepository = new Repository<RolePermissionEntity>(_context);
                return rolePermissionRepository;
            }
        }

        public IRepository<AuthorEntity> AuthorRepository
        {
            get
            {
                if (this.authorRepository == null)
                    this.authorRepository = new Repository<AuthorEntity>(_context);
                return authorRepository;
            }
        }

        public IRepository<BookEntity> BookRepository
        {
            get
            {
                if (this.bookRepository == null)
                    this.bookRepository = new Repository<BookEntity>(_context);
                return bookRepository;
            }
        }

        public IRepository<EditorialEntity> EditorialRepository
        {
            get
            {
                if (this.editorialRepository == null)
                    this.editorialRepository = new Repository<EditorialEntity>(_context);
                return editorialRepository;
            }
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        #endregion



        protected virtual void Dispose(bool disposing)
        {

            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<int> Save() => await _context.SaveChangesAsync();

    }
}
