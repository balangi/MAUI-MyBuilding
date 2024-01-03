#nullable disable

using Farabeh.MyBuilding.Framework.HttpClinet;
using Newtonsoft.Json;
using System.Text;

namespace Farabeh.MyBuilding.Framework.Results;

public static class ResultExtensions
{
    public static async Task<Result<T>> ToResult<T>(this HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode)
        {

            var responseAsString = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<T>(responseAsString);

            return Result.Ok(responseObject);
        }
        else
        {
            var responseAsString = await response.Content.ReadAsStringAsync();

            try
            {
                var responseObject = JsonConvert.DeserializeObject<FailResponse>(responseAsString);

                StringBuilder builder = new StringBuilder();

                foreach (var e in responseObject.Errors)
                {
                    builder.AppendFormat($"فیلد : { e.Key} ");
                    builder.AppendLine("\n");
                    builder.AppendFormat($"خطا : {string.Join(',', e.Value)}");
                    builder.AppendLine("\n");
                }

                return Result.Fail<T>(builder.ToString());
            }
            catch //(Exception ex)
            {
                try
                {
                    var responseObject = JsonConvert.DeserializeObject<string>(responseAsString);

                    StringBuilder builder = new StringBuilder();

                    foreach (var e in responseObject)
                    {
                        builder.AppendFormat($"خطا : {string.Join(',', e)}");
                        builder.AppendLine("\n");
                    }

                    return Result.Fail<T>(builder.ToString());

                }
                catch // (Exception ex1)
                {
                    try
                    {
                        var responseObject = JsonConvert.DeserializeObject<FailStatus>(responseAsString);

                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }

                //return Result.Fail<T>(response.ReasonPhrase);
                return Result.Fail<T>(responseAsString);
            }
        }
    }


    public static Result ToResult(this HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode)
        {
            return Result.Ok();
        }
        else
        {
            var responseAsString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            StringBuilder builder = new StringBuilder();
            try
            {
                var responseObject = JsonConvert.DeserializeObject<FailResponse>(responseAsString);


                foreach (var e in responseObject.Errors)
                {
                    builder.AppendFormat($"پراپرتی : { e.Key} ");
                    builder.Append("\n");
                    builder.AppendFormat($"خطا : {string.Join(',', e.Value)} ");
                    builder.Append("\n");
                }

                return Result.Fail(builder.ToString());
            }
            catch (Exception)
            {
                try
                {
                    var responseObject = JsonConvert.DeserializeObject<string[]>(responseAsString);
                    builder.Append("خطای ناشناخته => ");
                    builder.AppendJoin(",", responseObject);
                    return Result.Fail(builder.ToString());
                }
                catch (Exception)
                {

                    return Result.Fail(response.ReasonPhrase);
                }
            }
        }
    }
    public static bool IsEmpty<T>(this IEnumerable<T> ts)
    {
        if (ts == null || !ts.Any())
        {
            return true;
        }
        return false;
    }
    public static bool IsNotEmpty<T>(this IEnumerable<T> ts)
    {
        if (ts == null)
        {
            return false;
        }
        if (ts != null && ts.Any())
        {
            return true;
        }
        return false;
    }

    public static bool IsNull(this object obj)
    {
        return obj == null;
    }
    public static bool IsNotNull(this object obj)
    {
        return obj != null;
    }

    public static bool IsNullOrEmpty(this string str)
    {
        return string.IsNullOrEmpty(str);
    }
    public static bool IsNullOrWhiteSpace(this string str)
    {
        return string.IsNullOrWhiteSpace(str);
    }
    public static bool IsNotNullOrEmpty(this string str)
    {
        return !string.IsNullOrEmpty(str);
    }
    public static bool IsNotNullOrWhiteSpace(this string str)
    {
        return !string.IsNullOrWhiteSpace(str);
    }
}
