using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using ApiAngular.Utils;

namespace ApiAngular.Controllers
{
    public class DetectController : Controller
    {

        //private readonly string SystermId = "systemName";
        //[HttpPost("")]
        //public async Task<IActionResult> DetectAsync(IFormFile file)
        //{
        //    try
        //    {
        //        var systermId = User.Claims.FirstOrDefault(c => c.Type == SystermId).Value;
        //        #region check input
        //        file.ValidFile();
        //        #endregion
        //        #region add to S3
        //        var bucketExists = await _s3Service.AddBudgetAsync(systermId);
        //        if (!bucketExists) return NotFound($"Bucket {systermId} does not exist.");
        //        var fileName = Guid.NewGuid().ToString();
        //        var valueS3Return = await _s3Service.AddFileToS3Async(file, fileName, systermId, TypeOfRequest.Tagging);
        //        #endregion
        //        return Ok(new ResultResponse
        //        {
        //            Status = true,
        //            Message = "The system has received the file."
        //        });
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        _logger.LogException($"{MethodBase.GetCurrentMethod().Name} - {GetType().Name}", ex);
        //        return StatusCode(400, new ResultResponse
        //        {
        //            Status = false,
        //            Message = "Bad Request. Invalid value."
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogException($"{MethodBase.GetCurrentMethod().Name} - {GetType().Name}", ex);
        //        return StatusCode(500, new ResultResponse
        //        {
        //            Status = false,
        //            Message = "Internal Server Error"
        //        });
        //    }
        //}
    }
}
