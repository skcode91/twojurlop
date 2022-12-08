export const setLocalStorageItem = (key: string, value: unknown): void => {
  if (key) {
    const _value =
      value === "object" && value !== null ? JSON.stringify(value) : "";
    localStorage.setItem(key, _value);
  }
};

export const getLocalStorageItem = <T,>(key: string): T | undefined => {
  if (key) {
    const stringValue = localStorage.getItem(key);

    if (stringValue) {
      try {
        return JSON.parse(stringValue);
      } catch (err) {
        return undefined;
      }
    }
  }
};

export const getLocalStorageObject = <T,>(key: string): T | null => {
  if (key) {
    let stringValue: string | null;
    stringValue = localStorage.getItem(key);
    if (stringValue) {
      try {
        return JSON.parse(stringValue);
      } catch (err) {}
    }
  }
  return null;
};
