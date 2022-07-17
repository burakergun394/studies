using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Common.Wrappers;

public class BaseResponse
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
}

public class ServiceResponse<T>
{
    public T Value { get; set; }
    public ServiceResponse()
    {

    }

    public ServiceResponse(T value)
    {
        Value = value;
    }
}

public class PageResponse<T>: ServiceResponse<T>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    public PageResponse()
    {
        PageNumber = 1;
        PageSize = 10;
    }

    public PageResponse(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }

    public PageResponse(T value): base(value)
    {

    }
}
