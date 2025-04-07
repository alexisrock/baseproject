using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common;
using MediatR;

namespace Application.UseCases.ProductoCreate
{
    public class ProductoRequest : IRequest<BaseResponse>    {

    
        public string Name { get; set; } = string.Empty;
    }
}
