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
        private readonly IUnitOfWork _unitOfWork;

        public BookServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BookDto> GetById(int id)
        {
            BookEntity bookEntity = _unitOfWork.BookRepository.FirstOrDefault(x => x.Id == id);
            if (bookEntity == null)
                throw new BusinessException(GeneralMessages.ItemNoFound);

            var bookDto = new BookDto
            {
                Id = bookEntity.Id,
                Title = bookEntity.Title,
                Sinopsis = bookEntity.Sinopsis,
                N_Pages = bookEntity.N_Pages,
                UrlImage = bookEntity.UrlImage,
                IdAuthor = bookEntity.IdAuthor,
                AuthorName = bookEntity.AuthorEntity?.Name + " " + bookEntity.AuthorEntity?.LastName,
                IdEditorial = bookEntity.IdEditorial,
                EditorialName = bookEntity.EditorialEntity?.Name
            };

            return bookDto;
        }

        public async Task<IEnumerable<BookDto>> GetAll()
        {
            var bookEntities = _unitOfWork.BookRepository.GetAll().ToList();
            var bookDtos = bookEntities.Select(bookEntity => new BookDto
            {
                Id = bookEntity.Id,
                Title = bookEntity.Title,
                Sinopsis = bookEntity.Sinopsis,
                N_Pages = bookEntity.N_Pages,
                UrlImage = bookEntity.UrlImage,
                IdAuthor = bookEntity.IdAuthor,
                AuthorName = bookEntity.AuthorEntity?.Name + " " + bookEntity.AuthorEntity?.LastName,
                IdEditorial = bookEntity.IdEditorial,
                EditorialName = bookEntity.EditorialEntity?.Name
            });

            return bookDtos;
        }

        public async Task Create(BookDto bookDto)
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
            await _unitOfWork.Save();
        }

        public async Task Update(BookDto bookDto)
        {
            var bookEntity = _unitOfWork.BookRepository.FirstOrDefault(x => x.Id == bookDto.Id);
            if (bookEntity == null)
                throw new BusinessException("El libro no existe");

            bookEntity.Title = bookDto.Title;
            bookEntity.Sinopsis = bookDto.Sinopsis;
            bookEntity.N_Pages = bookDto.N_Pages;
            bookEntity.UrlImage = bookDto.UrlImage;
            bookEntity.IdAuthor = bookDto.IdAuthor;
            bookEntity.IdEditorial = bookDto.IdEditorial;

            _unitOfWork.BookRepository.Update(bookEntity);
            await _unitOfWork.Save();
        }

        public async Task Delete(int id)
        {
            var bookEntity = _unitOfWork.BookRepository.FirstOrDefault(x => x.Id == id);
            if (bookEntity == null)
                throw new BusinessException("El libro no existe");

            _unitOfWork.BookRepository.Delete(bookEntity);
            await _unitOfWork.Save();
        }
    }
}
