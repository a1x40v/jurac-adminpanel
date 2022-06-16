import { toast } from 'react-toastify';

export const toastSuccess = (message: string) => {
  toast(message, {
    position: 'bottom-right',
    autoClose: 3000,
    type: 'success',
  });
};

export const toastError = (message: string) => {
  toast(message, {
    position: 'bottom-right',
    autoClose: 3000,
    type: 'error',
  });
};
