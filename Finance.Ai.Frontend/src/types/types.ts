export interface CreateUserRequest {
  Email: string;
}

export interface CreateCategoryRequest {
  UserId: string;
  Name: string;
}

export interface AddTransactionRequest {
  UserId: string;
  CategoryId: string;
  TransactionTime: string;
  Name: string;
  Amount: number;
}

export interface Category {
  Id: string;
  Name: string;
}

export interface Transaction {
  Id: string;
  Name: string;
  Amount: number;
  CategoryId: string;
  TransactionTime: string;
} 