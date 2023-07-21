using Common.Exceptions;
using Common.Resources;
using Infraestructure.Entity.Models;
using Infraestructure.UnitOfWork.Interface;
using Library.Domain.Dto.Book;
using Library.Domain.Dto.Editorial;
using Library.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Services
{
    public class BookServices : IBookServices
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        #endregion


        #region Builder
        public BookServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        public BookEntity GetById(int id) => _unitOfWork.BookRepository.FirstOrDefault(x => x.Id == id);

        public List<BookDto> GetAll()
        {
            var bookEntities = _unitOfWork.BookRepository.GetAll();
            var bookDtos = bookEntities.Select(bookEntity => new BookDto
            {
                Id = bookEntity.Id,
                Title = bookEntity.Title,
                Sinopsis = bookEntity.Sinopsis,
                N_Pages = bookEntity.N_Pages,
                UrlImage = bookEntity.UrlImage,
                IdAuthor = bookEntity.IdAuthor,
                AuthorName = bookEntity.AuthorEntity.FullName,
                IdEditorial = bookEntity.IdEditorial,
                EditorialName = bookEntity.EditorialEntity.Name
            }).ToList();

            return bookDtos;
        }

        public async Task<bool> Create(AddBookDto bookDto)
        {
            if (_unitOfWork.BookRepository.FirstOrDefault(x => x.Title == bookDto.Title) != null)
                throw new BusinessException("No se puede insertar un libro duplicado");

            BookEntity bookEntity = new BookEntity
            {
                Title = bookDto.Title,
                Sinopsis = bookDto.Sinopsis,
                N_Pages = bookDto.N_Pages,
                UrlImage = bookDto.UrlImage,
                IdAuthor = bookDto.IdAuthor,
                IdEditorial = bookDto.IdEditorial
            };

            _unitOfWork.BookRepository.Insert(bookEntity);
            return await _unitOfWork.Save() > 0;
        }

        public async Task<bool> Update(UpdateBookDto bookDto)
        {
            var bookEntity = GetById(bookDto.Id);
            if (bookEntity == null)
                throw new BusinessException("El libro no existe");

            bookEntity.Title = bookDto.Title;
            bookEntity.Sinopsis = bookDto.Sinopsis;
            bookEntity.N_Pages = bookDto.N_Pages;
            bookEntity.UrlImage = bookDto.UrlImage;
            bookEntity.IdAuthor = bookDto.IdAuthor;
            bookEntity.IdEditorial = bookDto.IdEditorial;

            _unitOfWork.BookRepository.Update(bookEntity);

            return await _unitOfWork.Save() > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var bookEntity = GetById(id);
            if (bookEntity == null)
                throw new BusinessException("El libro no existe");

            _unitOfWork.BookRepository.Delete(bookEntity);

            return await _unitOfWork.Save() > 0;
        }
        #endregion
    }
}
