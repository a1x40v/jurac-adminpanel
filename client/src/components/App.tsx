import { Navigate } from 'react-router-dom';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import { ToastContainer } from 'react-toastify';

import { useAppSelector } from '../app/hooks/stateHooks';
import LeftNavBar from './common/layout/LeftNavBar';
import AbiturientDashboard from './features/abiturient/AbiturientDashboard';
import AbiturientDetail from './features/abiturient/AbiturientDetail';
import LoginForm from './features/auth/LoginForm';
import PublishRecTabDashboard from './features/publishRecTab/PublishRecTabDashboard';
import PublishTabDashboard from './features/publishTab/PublishTabDashboard';
import AppSettings from './features/settings/AppSettings';

const App = () => {
  const { account } = useAppSelector((state) => state.auth);

  if (!account) {
    return (
      <div className="flex flex-col items-center mt-10 font-nanito">
        <h1 className="mb-6">Панель управления базой данных СПбЮА</h1>
        <LoginForm />
        <ToastContainer />
      </div>
    );
  }

  return (
    <Router>
      <div className="flex font-nanito">
        <LeftNavBar />
        <Routes>
          <Route path="/" element={<Navigate to="/abiturients" />} />
          <Route path="/abiturients" element={<AbiturientDashboard />} />
          <Route path="/abiturients/:id" element={<AbiturientDetail />} />
          <Route path="/publishtabs" element={<PublishTabDashboard />} />
          <Route path="/publishrectabs" element={<PublishRecTabDashboard />} />
          <Route path="/settings" element={<AppSettings />} />
          <Route path="*" element={<AbiturientDashboard />} />
        </Routes>
        <ToastContainer />
      </div>
    </Router>
  );
};

export default App;
