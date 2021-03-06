﻿using Ecommerce.Core.Repositories;
using Ecommerce.Core.Services;
using Ecommerce.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ecommerce.Service.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TEntity> _repository;
        public Service(IUnitOfWork unitOfWork, IRepository<TEntity> repository) {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<TEntity> AddAsnyc(TEntity entity) {
            await _repository.AddAsnyc(entity);
            await _unitOfWork.CommitAsnyc();

            return entity;
        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities) {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsnyc();

            return entities;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsnyc() {
            return await _repository.GetAllAsnyc();

        }

        public async Task<TEntity> GetByIdAsync(int id) {
            return await _repository.GetByIdAsync(id);
        }

        public void Remove(TEntity entity) {
            _repository.Remove(entity);
            _unitOfWork.Commit();
        }

        public void RemoveRange(IEnumerable<TEntity> entities) {
            _repository.RemoveRange(entities);
            _unitOfWork.Commit();
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate) {
            return await _repository.SingleOrDefaultAsync(predicate);
        } 
        
        public async Task<TEntity> SingleOrDefaultAsNoTrackingAsync(Expression<Func<TEntity, bool>> predicate) {
            return await _repository.SingleOrDefaultAsNoTrackingAsync(predicate);
        }

        public TEntity Update(TEntity entity) {
            TEntity updateEntity = _repository.Update(entity);

            _unitOfWork.Commit();
            return updateEntity;
        }

        public async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate) {
            return await _repository.Where(predicate);
        }
    }
}
