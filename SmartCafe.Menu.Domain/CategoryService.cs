using SmartCafe.Menu.Domain.Models;
using SmartCafe.Menu.Domain.Models.Category;

namespace SmartCafe.Menu.Domain;

public class CategoryService : ICategoryService
{
    private static readonly Dictionary<string, CategoryDto> _storage = new Dictionary<string, CategoryDto>();
    public Task<Result<Guid, ErrorResult<CreateCategoryCommandErrorstatus>>> AddCategoryAsync(CreateCategoryCommand createCategoryCommand)
    {
        ArgumentNullException.ThrowIfNull(createCategoryCommand);

        if (_storage.ContainsKey(createCategoryCommand.Name))
        {
            return Task.FromResult(Result<Guid, ErrorResult<CreateCategoryCommandErrorstatus>>.Fail(
                new ErrorResult<CreateCategoryCommandErrorstatus>
                {
                    Status = CreateCategoryCommandErrorstatus.NameAlreadyExists,
                    Message = "The category with the same name already exists."
                }));
        }

        var entityWithSamePriority = _storage.Values.FirstOrDefault(x => x.Priority == createCategoryCommand.Priority);

        if (entityWithSamePriority is not null)
        {
            return Task.FromResult(Result<Guid, ErrorResult<CreateCategoryCommandErrorstatus>>.Fail(
                new ErrorResult<CreateCategoryCommandErrorstatus>
                {
                    Status = CreateCategoryCommandErrorstatus.NameAlreadyExists,
                    Message = "The category with the same priority already exists."
                }));
        }

        var guid = Guid.NewGuid();
        _storage.Add(
            createCategoryCommand.Name,
            new CategoryDto
        {
            Id = guid,
            Name = createCategoryCommand.Name,
            Priority = createCategoryCommand.Priority,
        });

        return Task.FromResult(Result<Guid, ErrorResult<CreateCategoryCommandErrorstatus>>.Success(guid));
    }

    public Task<CategoryDto?> GetCategoryAsync(Guid categoryId)
    {
        return Task.FromResult(_storage.Values.FirstOrDefault(x => x.Id == categoryId));
    }
}
