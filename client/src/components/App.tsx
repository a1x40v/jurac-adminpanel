import { Navigate } from 'react-router-dom';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';

import LeftNavBar from './common/layout/LeftNavBar';
import AbiturientDashboard from './features/abiturient/AbiturientDashboard';
import AppSettings from './features/settings/AppSettings';

const App = () => {
  return (
    <Router>
      <div className="flex first-line:font-nanito">
        <LeftNavBar />
        <div className="py-6 pr-6 mx-auto pl-9">
          <Routes>
            <Route path="/" element={<Navigate to="/abiturients" />} />
            <Route path="/abiturients" element={<AbiturientDashboard />} />
            <Route path="/settings" element={<AppSettings />} />
          </Routes>
        </div>
      </div>
    </Router>
  );
};

export default App;
