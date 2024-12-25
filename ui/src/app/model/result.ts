export interface Result<T> {
    success: Boolean;
    data: T;
    errorCode: Number;
    errorMessage: string;
}
