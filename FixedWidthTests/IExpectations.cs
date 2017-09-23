using System.Collections.Generic;

namespace FixedWidthTests
{

    public interface IExpectations<T>
    {

        ICollection<T> List();

    }

}
