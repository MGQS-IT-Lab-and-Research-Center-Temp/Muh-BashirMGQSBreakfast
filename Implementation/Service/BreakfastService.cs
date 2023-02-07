using MGQSBreakfast.Context;
using MGQSBreakfast.Contracts.Services;
using MGQSBreakfast.Contracts.Repositories;
using MGQSBreakfast.Entities;
using MGQSBreakfast.Implementation.Repository;
using MGQSBreakfast.Models;
using MGQSBreakfast.Models.Response;

namespace MGQSBreakfast.Implementations.Service
{
    public class BreaskfastService : IBreakfastService
    {

        private readonly IBreakfastRepository _breakfastRepository;

        public BreaskfastService(ApplicationDbContext context, IBreakfastRepository breakfastRepository)
        {
            _breakfastRepository = breakfastRepository;
        }
        public BreakfastResponseModel DeleteBreakfast(int id)
        {
            var breakfast = _breakfastRepository.GetById(id);
            if (breakfast == null)
            {
                return new BreakfastResponseModel
                {
                    Message = "Breakfast Not found!!",
                    Status = false
                };
            }

            _breakfastRepository.Delete(id);
            return new BreakfastResponseModel
            {
                Message = "Breakfast Succesfully deleted",
                Status = true
            };


        }

        public BreakfastResponseModel GetBreakfast(int id)
        {
            var breakfast = _breakfastRepository.GetById(id);
            if (breakfast == null)
            {
                return new BreakfastResponseModel
                {
                    Message = "Breakfast not found!!",
                    Status = false
                };
            }
                return new BreakfastResponseModel
                {
                    Data = new CreateBreakfastViewModel
                    {
                        Id = breakfast.Id,
                        Name = breakfast.Name,
                        Description = breakfast.Description,
                        StartDateTime = breakfast.StartDateTime,
                        EndDateTime = breakfast.EndDateTime
                    },
                    Status = true,
                    Message = "Breakfast successfully retrieved"
                };

        }

        public BreakfastResponseModels GetAllBreakfast()
        {
            var breakfasts = _breakfastRepository.GetAll();
            if (breakfasts == null)
            {
                return new BreakfastResponseModels
                {
                    Status = false,
                    Message = "breakfast Not Found",
                };
            }

            return new BreakfastResponseModels
            {
                Data = breakfasts,
                Status = true,
                Message = "List of admins",
            };
        }                                                 

        public BreakfastResponseModel CreateBreakfast(CreateBreakfastViewModel request)
        {
            var breakfast = _breakfastRepository.GetById(request.Id);
            if (breakfast != null)
            {
                return new BreakfastResponseModel
                {
                    Message = "Breakfast already exist!!",
                    Status = false
                };
            }
            var newbreakfast = new Breakfast
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                StartDateTime = request.StartDateTime,
                EndDateTime = request.EndDateTime
            };
            _breakfastRepository.Create(newbreakfast);
            return new BreakfastResponseModel
            {
                Data = new CreateBreakfastViewModel
                {
                    Name = newbreakfast.Name,
                    Description = newbreakfast.Description,
                    StartDateTime = newbreakfast.StartDateTime,
                    EndDateTime = newbreakfast.EndDateTime
                },
                Message = "Breakfast successfully created",
                Status = true
            };
        }

        public BreakfastResponseModel UpdateBreakfast(int id, UpdateBreakfastViewModel request)
        {
            var breakfast = _breakfastRepository.GetById(id);
            if (breakfast == null)
            {
                return new BreakfastResponseModel
                {
                    Message = "Breakfast not found!!",
                    Status = false
                };
            }
                //breakfast.Id = request.Id;
                breakfast.Name = request.Name;
                breakfast.Description = request.Description;
                //breakfast.StartDateTime = request.StartDateTime;
                //breakfast.EndDateTime = request.EndDateTime; 
                _breakfastRepository.Update(id);
                return new BreakfastResponseModel
                {
                    Message = "Breakfast successfully updated",
                    Status = true
                };
        }

        
    }
}
