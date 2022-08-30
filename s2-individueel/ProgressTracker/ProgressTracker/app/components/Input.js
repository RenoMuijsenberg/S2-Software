import {useController} from "react-hook-form";
import {TextInput, Text, View} from "react-native";
import {Controller} from "react-hook-form";
import styles from "../styles/componentStyles/Input.styles"

const Input = ({name, control, type, required, label}) => {
    const {} = useController({
        control,
        defaultValue: "",
        name
    })
    if (type === "password") {
        return (
            <View>
                <Text style={styles.label}>{name}:</Text>
                <Controller
                    control={control}
                    render={({field: {onChange, onBlur, value}}) => (
                        <TextInput
                            style={styles.input}
                            onBlur={onBlur}
                            onChangeText={value => onChange(value)}
                            value={value}
                            secureTextEntry={true}
                        />
                    )}
                    name={name}
                    rules={{
                        required: {
                            value: true,
                            message: "This field is required"
                        }
                    }}
                />
            </View>
        )
    } else if (type === "email") {
        return (
            <View>
                <Text style={styles.label}>{name}:</Text>
                <Controller
                    control={control}
                    render={({field: {onChange, onBlur, value}}) => (
                        <TextInput
                            style={styles.input}
                            onBlur={onBlur}
                            onChangeText={value => onChange(value)}
                            value={value}
                            secureTextEntry={false}
                        />
                    )}
                    name={name}
                    rules={{
                        required: {
                            value: true,
                            message: "This field is required"
                        },                    
                        pattern: {
                            value: /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/,
                            message: "This is not a valid email address"
                        }
                    }}
                />
            </View>
        )
    } else {
        return (
            <View>
                <Text style={styles.label}>{label}:</Text>
                <Controller
                    control={control}
                    render={({field: {onChange, onBlur, value}}) => (
                        <TextInput
                            style={styles.input}
                            onBlur={onBlur}
                            onChangeText={value => onChange(value)}
                            value={value}
                        />
                    )}
                    name={name}
                    rules={{
                        required: {
                            value: required,
                            message: "This field is required"
                        }
                    }}
                />
            </View>
        )
    }
}

export default Input;