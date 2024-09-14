﻿namespace BookManager.Domain.Abstractions.Repositories;

public interface IUnitOfWork
{
    Task CommitAsync();

    void RollbackAsync();
}