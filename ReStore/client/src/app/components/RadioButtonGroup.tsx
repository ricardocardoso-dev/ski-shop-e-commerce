import { FormControl, FormLabel, RadioGroup, FormControlLabel, Radio } from "@mui/material";

interface Props {
    title: string,
    options: any[];
    onChange: (event: any) => void;
    selectedValue: string;
};

export default function RadioButtonGroup({ title, options, onChange, selectedValue }: Props) {
    return (
        <FormControl component="fieldset">
            <FormLabel id="demo-radio-buttons-group-label">{title}</FormLabel>
            <RadioGroup onChange={onChange} value={selectedValue}>
                {options.map(({ value, label }) => (
                    <FormControlLabel key={value} value={value} control={<Radio />} label={label} />
                ))}
            </RadioGroup>
        </FormControl>
    )
}