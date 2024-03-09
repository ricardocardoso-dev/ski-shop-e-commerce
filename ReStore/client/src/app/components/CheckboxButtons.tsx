import { FormGroup, FormLabel, FormControlLabel, Checkbox } from "@mui/material";
import { useState } from "react";

interface Props {
    title: string,
    items: string[];
    checked: string[] | undefined;
    onChange: (items: string[]) => void;
}

export default function CheckboxButtons({ title, items, checked, onChange }: Props) {
    const [checkedItems, setCheckedItems] = useState(checked || []);

    function handleChecked(value: string) {
        const currentIndex = checkedItems.findIndex(item => item === value);
        let newChecked: string[] = [];
        if (currentIndex === - 1) newChecked = [...checkedItems, value];
        else newChecked = checkedItems.filter(item => item !== value);
        setCheckedItems(newChecked);
        onChange(newChecked);
    };

    return (
        <FormGroup>
            <FormLabel id="">{title}</FormLabel>
            {items.map((item) => (
                <FormControlLabel
                    key={item}
                    control={<Checkbox
                        checked={checkedItems.indexOf(item) !== -1}
                        onClick={() => handleChecked(item)}
                    />}
                    label={item}
                />
            ))}
        </FormGroup>
    )
};