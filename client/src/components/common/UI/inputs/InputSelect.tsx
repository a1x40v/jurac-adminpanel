import Select, { GroupBase, MenuPlacement, StylesConfig } from 'react-select';

export interface SelectOption<T> {
  value: T;
  label: string;
}

interface Props<IsMulti extends boolean, OptValue> {
  options: SelectOption<OptValue>[];
  defaultValue: SelectOption<OptValue> | SelectOption<OptValue>[];
  menuWidth?: string;
  isMulti?: IsMulti;
  menuPlacement?: MenuPlacement;
  onChange: (val: SelectOption<OptValue> | SelectOption<OptValue>[]) => void;
}

const InputSelect = <IsMulti extends boolean, OptValue>(
  props: Props<IsMulti, OptValue>
) => {
  const {
    options,
    defaultValue,
    menuWidth,
    isMulti,
    menuPlacement = 'bottom',
    onChange,
  } = props;

  const styles: StylesConfig<
    SelectOption<OptValue>,
    IsMulti,
    GroupBase<SelectOption<OptValue>>
  > = {
    menu: (provided) => ({
      ...provided,
      width: menuWidth ? menuWidth : 'auto',
    }),
    option: (provided, state) => ({
      ...provided,
      backgroundColor: state.isSelected
        ? 'rgba(3,105,161)'
        : state.isFocused
        ? 'rgba(3,105,161,0.2)'
        : undefined,
    }),
    control: (provided, state) => ({
      ...provided,
      maxWidth: '1200px',
      borderColor: state.isFocused ? 'rgba(3,105,161)' : 'gray',
      boxShadow: 'none',
      ':hover': {
        borderColor: 'rgba(3,105,161)',
      },
    }),
  };

  return (
    <Select
      isMulti={isMulti}
      options={options}
      defaultValue={defaultValue}
      onChange={(data) => {
        if (data) {
          onChange(Array.isArray(data) ? data : (data as any).value);
        }
      }}
      styles={styles}
      menuPlacement={menuPlacement}
    />
  );
};

export default InputSelect;
