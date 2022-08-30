import {Alert, SafeAreaView, Text, TouchableHighlight, View} from 'react-native';
import {StatusBar} from "expo-status-bar";
import Input from "../components/Input";
import {useForm} from "react-hook-form";
import axios from "../Axios";
import styles from "../styles/Main.styles"

function CreateExerciseScreen({ navigation, route }) {
    const {control, handleSubmit, formState: { errors } } = useForm();
    
    const scheme = route.params;
    
    const CreateNewExercise = async (data) => {
        data.schemeId = scheme.id;
        
        await axios.post("exercise/create", JSON.stringify(data)).then(response =>{
            Alert.alert("Success", response.data.userMessage);
            navigation.goBack();
        });
    }

    return (
        <SafeAreaView style={styles.container}>
            <StatusBar style="light"/>
            <View>
                <Input label={"Name"} name="Name" required={true} control={control}/>
                {errors.Name && <Text style={styles.error}>{errors.Name.message}</Text>}
                <Input label={"Sets"} name="Sets" required={false} control={control}/>
                {errors.Sets && <Text style={styles.error}>{errors.Sets.message}</Text>}
                <Input label={"Note"} name="Note" required={false} control={control}/>
                {errors.Note && <Text style={styles.error}>{errors.Note.message}</Text>}
            </View>
            <View>
                <TouchableHighlight style={styles.buttonOutline} onPress={handleSubmit(CreateNewExercise)}>
                    <Text style={styles.buttonText}>Create new workout scheme</Text>
                </TouchableHighlight>
            </View>
        </SafeAreaView>
    );
}

export default CreateExerciseScreen;