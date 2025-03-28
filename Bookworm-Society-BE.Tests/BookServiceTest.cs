﻿using Bookworm_Society_API.DTOs;
using Bookworm_Society_API.Helpers;
using Bookworm_Society_API.Interfaces;
using Bookworm_Society_API.Models;
using Bookworm_Society_API.Repositories;
using Bookworm_Society_API.Services;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookworm_Society_BE.Tests
{
    public class BookServiceTest
    {

        private readonly BookService _bookService;
        private readonly Mock<IBookRepository> _mockBookRepository;
        private readonly Mock<IBaseRepository> _mockBaseRepository;

        public BookServiceTest()
        {
            _mockBookRepository = new Mock<IBookRepository>();
            _mockBaseRepository = new Mock<IBaseRepository>();
            _bookService = new BookService(_mockBookRepository.Object, _mockBaseRepository.Object);
        }


        [Fact]
        public async Task GetAllBooks_ShouldReturnListOfBookDTOS()
        {
            //ARANGE
            int pageNumber = 1;
            int pageSize = 2;
            int totalCount = 2;

                // we only need a list of books and to include the Author Model since that is what we do in the repo layer for this method
            var expectedBookList = new List<Book>
            {
               new Book
                {
                    Id = 1,
                    Title = "Test",
                    Description = "Test",
                    AuthorId = 1,
                    GenreId = 5,
                    ImageUrl = "Test",
                    Author = new Author { Id = 1, FirstName = "John", LastName = "Doe" }
                },
                new Book
                {
                    Id = 2,
                    Title = "Test",
                    Description = "Test",
                    AuthorId = 2,
                    GenreId = 3,
                    ImageUrl = "Test",
                    Author = new Author { Id = 2, FirstName = "Jane", LastName = "Smith" }
                }
            };

                // Now we need to pass PagedList the expectedBookList and the page number and page size. Again similar to what is happening in the repo layer 
            var pagedBooks = PagedList<Book>.Create(expectedBookList, pageNumber, pageSize);

                // In out service layer we map what we get back from the repo and make sure that the books are converted to dtos 
            var expectedPagedBooksDTOList = expectedBookList.Select(book => new BookDTO(book)).ToList();

            //MOCK
                //"When someone calls GetPaginatedBooksAsync(pageNumber, pageSize) inside this test, return pagedBooks instead of making a real database query.
            _mockBookRepository
                .Setup(repo => repo.GetPaginatedBooksAsync(pageNumber, pageSize))
                .ReturnsAsync(pagedBooks);

            //ACT
                //it receives the mocked data instead of querying the actual database.
                //service method is actually executing, and when it calls _bookRepository.GetPaginatedBooksAsync(...),
                //it gets the mocked response (pagedBooks).
            var result = await _bookService.GetPaginatedBooksAsync(pageNumber, pageSize);

            //ASSERT
                // we grab the result and insure it's equal to the dto list 
            result.Items.Should().BeEquivalentTo(expectedPagedBooksDTOList);  // Asserting that BookDTOs match the expected list
            result.PageNumber.Should().Be(pagedBooks.PageNumber);
            result.PageSize.Should().Be(pagedBooks.PageSize);
            result.TotalCount.Should().Be(pagedBooks.TotalCount);
            result.HasNextPage.Should().Be(pagedBooks.HasNextPage);
            result.HasPreviousPage.Should().Be(pagedBooks.HasPreviousPage);

        }

        [Fact]
        public async Task GetSingleBook_WhereBookExist_ShouldReturnBookDetail()
        {

        //ARRANGE 
            int bookId = 103;

            var book = new Book
            {
                Id = bookId,
                Title = "Title",
                Description = "Description",
                AuthorId = 3,
                Author = new Author { Id = 3, FirstName = "sara", LastName = "june" },
                GenreId = 4,
                Genre = new Genre { Id = 4, Name = "genre name" },
                ImageUrl = "image",
                Reviews = new List<Review>
                {
                    new Review {
                        Id = 2,
                        Content = "content",
                        CreatedDate = new DateTime(2023, 2, 15),
                        Rating = 3,
                        User = new User
                        { Id = 1,
                            FirstName = "John",
                            LastName = "Doe",
                            ImageUrl = "https://example.com/johndoe.jpg",
                            Username = "johndoe",
                            Uid = "useruid123"
                        }
                    }
                }
            };

            var expectedBook = new
            {
                book.Id,
                book.Title,
                book.Description,
                Author = $"{book.Author.FirstName} {book.Author.LastName}",
                Genre = book.Genre.Name,
                book.ImageUrl,
                Reviews = book.Reviews?
         .OrderBy(r => r.CreatedDate)
         .Select(r => new
         {
             r.Id,
             r.Content,
             r.CreatedDate,
             r.Rating,
             User = new UserDTO(r.User)
         }).ToList()
            };


            //MOCK
            _mockBookRepository
                .Setup(repo => repo.GetSingleBookAsync(bookId))
                .ReturnsAsync(book);

            _mockBaseRepository
                .Setup(repo => repo.BookExistsAsync(bookId))
                .ReturnsAsync(true);



        //ACT
        var result = await _bookService.GetSingleBookAsync(bookId);


        //ASSERT
        result.Should().NotBeNull();
        result.Success.Should().BeTrue();
        result.Data.Should().NotBeNull();
        result.Data.Should().BeEquivalentTo(expectedBook);

        }

    }
}
