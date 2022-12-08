export const getWindow = (): (Window & typeof globalThis) | undefined => {
  if (typeof window !== "undefined" && window) {
    return window;
  }
  return undefined;
};
