using Equipments.Domain.QueryModels.Equipments;

namespace Equipments.Domain.Interfaces.Queries;

/// <summary>
/// Предоставляет методы для выполнения запросов к данным оборудования.
/// </summary>
public interface IEquipmentQueries
{
    /// <summary>
    /// Получает отфильтрованный диапазон оборудования с количеством.
    /// </summary>
    /// <param name="countSkip">Количество пропускаемых записей.</param>
    /// <param name="countTake">Количество получаемых записей.</param>
    /// <param name="equipmentFilterModel">Модель фильтра для поиска оборудования.</param>
    /// <returns>Задача, результатом которой является кортеж содержащий список оборудования и количество с учетом фильтра.</returns>
    Task<(List<EquipmentDetailsListModel> Equipments, int CountEquipmentsWithFilter)> GetFilteredRangeAsync(
        int countSkip,
        int countTake,
        EquipmentFilterModel equipmentFilterModel);

    /// <summary>
    /// Получает детальную информацию об оборудовании по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор оборудования.</param>
    /// <returns>Задача, результатом которой является детальная модель оборудования или null если не найдено.</returns>
    Task<EquipmentDetailsModel?> GetDetailsByIdAsync(int id);
}