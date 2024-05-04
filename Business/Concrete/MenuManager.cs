using AutoMapper;
using Business.Abstract;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MenuManager : IMenuService
    {
        private readonly IMenuDal _menuDal;
        private readonly IMapper _mapper;

        public MenuManager(IMenuDal menuDal, IMapper mapper)
        {
            _menuDal = menuDal;
            _mapper = mapper;
        }

        public IResult CreateMenu(CreateMenuDto createMenuDto)
        {
            //automapper gelecek buraya
            var menu = _mapper.Map<Menu>(createMenuDto);

            _menuDal.Add(menu);
            return new SuccessResult(Messages.AddProcessSuccess);

        }

        public async Task<IDataResult<List<MenuComponentDto>>> GetAllMenus()
        {
            //IResult result = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(),
            //    CheckIfProductCountOfCategoryCorrect());
            //if (result != null)
            //{
            //    return result;
            //}


            var data = _menuDal.GetAll();

            var menuList = new List<MenuComponentDto>();

            foreach (var item in data)
            {
                var res = new MenuComponentDto()
                {
                    Icon = item.Icon,
                    Index = item.Index,
                    Name = item.Name,
                    Url = item.Url
                };
                menuList.Add(res);
            }
            return new SuccessDataResult<List<MenuComponentDto>>(menuList);

            //ValidationTool.Validate(new ProductValidator(), data);
        }
        private IResult CheckIfProductCountOfCategoryCorrect()
        {
            //iş kuralları bu şekilde yazılacak
            return new SuccessResult();
        }
    }
}
