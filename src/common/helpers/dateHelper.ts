import { format } from "date-fns";

export const getDisplayedDate = (date: Date, locale: Locale) => {
  let dateFormat = "PPP";

  return format(date, dateFormat, { locale });
};
