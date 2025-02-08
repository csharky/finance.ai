import { Category, Transaction, AddTransactionRequest } from '../types/types';

const API_BASE_URL = 'http://localhost:5143';

export const api = {
  async createUser(email: string): Promise<string> {
    try {
      const response = await fetch(`${API_BASE_URL}/api/users/create?api-version=1.0`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ email })
      });
      const data = await response.json();
      console.log('Create user response:', data);
      return data.Id;
    } catch (error) {
      console.error('Create user error:', error);
      throw error;
    }
  },

  async createCategory(userId: string, name: string): Promise<void> {
    await fetch(`${API_BASE_URL}/api/categories/create?api-version=1.0`, {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({ userId, name })
    });
  },

  async fetchCategories(userId: string): Promise<Category[]> {
    try {
      console.log('Fetching categories for userId:', userId);
      const response = await fetch(`${API_BASE_URL}/api/categories/fetchAll?userId=${userId}&api-version=1.0`);
      const data = await response.json();
      console.log('Categories response:', data);
      return data.Categories || [];
    } catch (error) {
      console.error('Error fetching categories:', error);
      return [];
    }
  },

  async addTransaction(transaction: AddTransactionRequest): Promise<void> {
    try {
      console.log('Adding transaction:', transaction);
      const response = await fetch(`${API_BASE_URL}/api/transactions/add?api-version=1.0`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
          UserId: transaction.UserId,
          CategoryId: transaction.CategoryId,
          TransactionTime: transaction.TransactionTime,
          Name: transaction.Name,
          Amount: transaction.Amount
        })
      });
      if (!response.ok) {
        const error = await response.json();
        console.error('Error adding transaction:', error);
        throw new Error(error.title || 'Failed to add transaction');
      }
    } catch (error) {
      console.error('Error adding transaction:', error);
      throw error;
    }
  },

  async fetchTransactions(userId: string): Promise<Transaction[]> {
    try {
      console.log('Fetching transactions for userId:', userId);
      const response = await fetch(`${API_BASE_URL}/api/transactions/fetchAll?userId=${userId}&api-version=1.0`);
      const data = await response.json();
      console.log('Transactions response:', data);
      return data.Transactions || [];
    } catch (error) {
      console.error('Error fetching transactions:', error);
      return [];
    }
  }
}; 