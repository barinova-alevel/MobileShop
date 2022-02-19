export interface PaginatedDto<T> { 
    pageCount: number;
    data: T[];
};