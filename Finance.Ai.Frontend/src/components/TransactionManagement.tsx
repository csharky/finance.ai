import React, { useState, useEffect } from 'react';
import { api } from '../services/api';
import { Transaction, Category } from '../types/types';

interface Props {
  userId: string;
}

const TransactionManagement: React.FC<Props> = ({ userId }) => {
  const [transactions, setTransactions] = useState<Transaction[]>([]);
  const [categories, setCategories] = useState<Category[]>([]);
  const [newTransaction, setNewTransaction] = useState({
    Name: '',
    Amount: 0,
    CategoryId: '',
    TransactionTime: new Date().toISOString().split('T')[0]
  });

  useEffect(() => {
    loadTransactions();
    loadCategories();
  }, [userId]);

  const loadTransactions = async () => {
    try {
      const data = await api.fetchTransactions(userId);
      console.log('Transactions data:', data);
      setTransactions(Array.isArray(data) ? data : []);
    } catch (error) {
      console.error('Failed to load transactions:', error);
      setTransactions([]);
    }
  };

  const loadCategories = async () => {
    try {
      const data = await api.fetchCategories(userId);
      console.log('Categories data:', data);
      setCategories(Array.isArray(data) ? data : []);
    } catch (error) {
      console.error('Failed to load categories:', error);
      setCategories([]);
    }
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    if (!newTransaction.CategoryId) {
      alert('Please select a category');
      return;
    }
    try {
      await api.addTransaction({
        ...newTransaction,
        UserId: userId,
        TransactionTime: new Date(newTransaction.TransactionTime).toISOString()
      });
      setNewTransaction({
        Name: '',
        Amount: 0,
        CategoryId: '',
        TransactionTime: new Date().toISOString().split('T')[0]
      });
      await loadTransactions();
    } catch (error) {
      console.error('Failed to add transaction:', error);
    }
  };

  const getCategoryName = (categoryId: string) => {
    const category = categories.find(c => c.Id === categoryId);
    return category ? category.Name : 'Unknown Category';
  };

  return (
    <div className="max-w-md mx-auto mt-8">
      <form onSubmit={handleSubmit} className="space-y-4">
        <input
          type="text"
          value={newTransaction.Name}
          onChange={(e) => setNewTransaction({...newTransaction, Name: e.target.value})}
          placeholder="Transaction name"
          className="w-full p-2 border rounded"
          required
        />
        <input
          type="number"
          value={newTransaction.Amount}
          onChange={(e) => setNewTransaction({...newTransaction, Amount: parseFloat(e.target.value)})}
          placeholder="Amount"
          className="w-full p-2 border rounded"
          required
          step="0.01"
        />
        <select
          value={newTransaction.CategoryId}
          onChange={(e) => setNewTransaction({...newTransaction, CategoryId: e.target.value})}
          className="w-full p-2 border rounded"
          required
        >
          <option value="">Select Category</option>
          {categories.map((category) => (
            <option key={category.Id} value={category.Id}>
              {category.Name}
            </option>
          ))}
        </select>
        <input
          type="date"
          value={newTransaction.TransactionTime}
          onChange={(e) => setNewTransaction({...newTransaction, TransactionTime: e.target.value})}
          className="w-full p-2 border rounded"
          required
        />
        <button type="submit" className="w-full p-2 bg-blue-500 text-white rounded">
          Add Transaction
        </button>
      </form>

      <div className="mt-8">
        <h3 className="text-lg font-bold mb-4">Transactions</h3>
        <ul className="space-y-2">
          {transactions.map((transaction) => (
            <li key={transaction.Id} className="p-2 bg-gray-100 rounded">
              <div>{transaction.Name} - ${transaction.Amount}</div>
              <div className="text-sm text-gray-600">
                Category: {getCategoryName(transaction.CategoryId)}
              </div>
              <div className="text-sm text-gray-600">
                Date: {new Date(transaction.TransactionTime).toLocaleDateString()}
              </div>
            </li>
          ))}
        </ul>
      </div>
    </div>
  );
};

export default TransactionManagement; 