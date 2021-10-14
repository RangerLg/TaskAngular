using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskAngular.Resource.api.Models
{
    public class BookStore
    {
        public List<Book> Books => new List<Book>
        {
            new Book{id=1, author ="1",title="1",price=10},
            new Book{id=2, author ="2",title="2",price=100},
            new Book{id=3, author ="3",title="3",price=1000},
            new Book{id=4, author ="4",title="4",price=10000},
        };

        public Dictionary<Guid, int[]> Orders => new Dictionary<Guid, int[]>
        {
            {Guid.Parse("65fe2aac-88dd-4236-9f3e-ee81de8c2430"), new int[]{1,3 } },
            {Guid.Parse("c52af4f3-d010-4c83-b920-ca3599cb769f"), new int[]{2,3,4 } },
        };
    }
}
