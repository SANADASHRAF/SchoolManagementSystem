﻿using Contracts;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class BookService : IBookService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public BookService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

    }
}