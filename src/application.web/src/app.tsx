import './index.css';
import { Routes, Route } from 'react-router-dom';
import RootLayout from './layout';
import Employee from './pages/Employee';

export default function App() {
  return (
    <Routes>
      <Route element={<RootLayout />}>
        <Route path='/' element={<Employee />} />
        <Route path='*' element={<div>Not Found</div>} />
      </Route>
    </Routes>
  );
}
