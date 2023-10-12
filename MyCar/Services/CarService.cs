using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCar.Context;
using MyCar.DTOs;
using MyCar.Mappers;
using MyCar.Models;
using MyCar.Repositories;
using MyCar.Repositories.Interfaces;
using MyCar.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCar.Services
{
    public class CarService : ICarService
    {
        private IBaseRepository<CarModel> _baseRepository = null;

        public CarService(){
            _baseRepository = new BaseRepository<CarModel>();
        }

        public async Task<List<CarDTO>> GetCars()
        {
            return CarMapper.FromModelToDTOList(await _baseRepository.GetAll().ToListAsync());
        }

        public async Task<CarDTO> GetCarById(int id)
        {
            return CarMapper.FromModelToDTO(await _baseRepository.GetByWhere(a => a.Id == id).FirstOrDefaultAsync());
        }

        public async Task CreateCars(CarDTO carDTO)
        {
            await _baseRepository.CreateAsync(CarMapper.FromDTOToModel(carDTO));
        }

        public async Task UpdateCar(int id, CarDTO carDTO)
        {
            var carModel = CarMapper.FromDTOToModel(carDTO);
            carModel.Id = id;
            await _baseRepository.UpdateAsync(carModel);
        }

        public async Task RemoveCarById(int id)
        {
            var carDTO = await GetCarById(id);
            await _baseRepository.DeleteAsync(CarMapper.FromDTOToModel(carDTO));
        }
    }
    

}
