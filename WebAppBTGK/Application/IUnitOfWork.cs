using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IUnitOfWork
    {
        IBookRepository Book { get; }
        IGenreRepository Genre { get; }
        Task<bool> Complete();
    }
}
