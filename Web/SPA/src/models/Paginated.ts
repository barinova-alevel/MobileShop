export interface Paginated<T>{
    pageIndex: number;
    pageSize: number;
    count: number;
    data: T[];
}