using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using FluentValidation;
using MediatR;

namespace Application.UseCases.ProductoCreate
{
    public class ProductoCreateHandler : IRequestHandler<ProductoRequest, BaseResponse>
    {
        private readonly IValidator<ProductoRequest> validator;
        private readonly IProductoRepository productoRepository;

        public ProductoCreateHandler(IValidator<ProductoRequest> validator, IProductoRepository productoRepository)
        {
            this.validator = validator;
            this.productoRepository = productoRepository;
        }

        public async Task<BaseResponse> Handle(ProductoRequest request, CancellationToken cancellationToken)
        {

            
            try
            {
                var result = await validator.ValidateAsync(request);
                if (!result.IsValid)
                {
                    throw new ApiException(result.Errors.ToString(), (int)System.Net.HttpStatusCode.BadRequest);
                }

                var producto = new Producto(request.Name);
                await productoRepository.Create(producto);
                return new BaseResponse()
                {
                    message = "Producto registrado con exito"
                };
            }
            catch (Exception ex) when (ex is ApiException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ApiException("Ocurrió un error inesperado", (int)System.Net.HttpStatusCode.InternalServerError);
            }
        }
    }
}
