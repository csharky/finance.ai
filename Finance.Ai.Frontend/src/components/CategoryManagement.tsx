import React, { useState, useEffect } from 'react';
import { api } from '../services/api';
import { Category } from '../types/types';

interface Props {
  userId: string;
}

const CategoryManagement: React.FC<Props> = ({ userId }) => {
  const [categories, setCategories] = useState<Category[]>([]);
  const [newCategoryName, setNewCategoryName] = useState('');

  useEffect(() => {
    loadCategories();
  }, [userId]);

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
    try {
      await api.createCategory(userId, newCategoryName);
      setNewCategoryName('');
      await loadCategories();
    } catch (error) {
      console.error('Failed to create category:', error);
    }
  };

  return (
    <div className="max-w-md mx-auto mt-8">
      <form onSubmit={handleSubmit} className="mb-4">
        <input
          type="text"
          value={newCategoryName}
          onChange={(e) => setNewCategoryName(e.target.value)}
          placeholder="New category name"
          className="w-full p-2 border rounded"
          required
        />
        <button type="submit" className="w-full mt-2 p-2 bg-green-500 text-white rounded">
          Add Category
        </button>
      </form>

      <div className="mt-4">
        <h3 className="text-lg font-bold mb-2">Categories</h3>
        <ul className="space-y-2">
          {categories.map((category) => (
            <li key={category.Id} className="p-2 bg-gray-100 rounded">
              {category.Name}
            </li>
          ))}
        </ul>
      </div>
    </div>
  );
};

export default CategoryManagement; 