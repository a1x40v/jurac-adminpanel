import { useAppDispatch, useAppSelector } from '../../../app/hooks/stateHooks';
import { removeCredentials } from '../../../app/state/slices/authSlice';
import Button from '../../common/UI/inputs/Button';

const AppSettings = () => {
  const dispatch = useAppDispatch();
  const { account } = useAppSelector((state) => state.auth);

  return (
    <div>
      <h2 className="text-center">Авторизация</h2>
      <div className="flex flex-col mt-6">
        <span className="mb-2">Вы авторизованы как: {account?.username}</span>
        <Button label="Выйти" onClick={() => dispatch(removeCredentials())} />
      </div>
    </div>
  );
};

export default AppSettings;
